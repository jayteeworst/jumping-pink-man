using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Platformer
{
    public abstract class RandomizedContainer : InteractableObject
    {
        public DropTable dropTable;
        public List<GameObject> contents = new();
        [SerializeField] private int itemAmount = 1;

        protected override void Awake()
        {
            base.Awake();
            if (dropTable == null)
            {
                Debug.LogError(gameObject.name + ": missing drop table!");
                return;
            }

            RandomizeContents();
        }

        private void RandomizeContents()
        {
            float totalWeight = dropTable.TotalWeight();

            for (int i = 0; i < itemAmount; i++)
            {
                float roll = Random.Range(0f, totalWeight);
                float progress = 0f;

                foreach (var item in dropTable.possibleDrops)
                {
                    progress += item.dropChance;
                    if (progress > roll)
                    {
                        contents.Add(item.prefabSource);
                        break;
                    }
                }
            }
        }

        protected void SpawnContents()
        {
            foreach (var valuable in contents)
            {
                Instantiate(valuable, transform.position + new Vector3(Random.Range(-1f, 1f), 0, -0.1f),
                    Quaternion.identity);
            }
        }
    }
}