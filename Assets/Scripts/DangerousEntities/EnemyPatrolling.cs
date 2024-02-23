using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class EnemyPatrolling : Enemy
    {
        [SerializeField] private Transform startTransform;
        [SerializeField] private Transform finishTransform;
        [SerializeField] private float patrolDuration;
        [SerializeField] private float waitDuration;

        private void Start()
        {
            StartCoroutine(Patrol(startTransform.position, finishTransform.position));
        }

        protected override void Destroyed()
        {
            base.Destroyed();
            StopAllCoroutines();
        }

        private IEnumerator Patrol(Vector2 startPosition, Vector2 finishPosition)
        {
            var startTime = Time.time;

            while ((Vector2)transform.position != finishPosition)
            {
                transform.position =
                    Vector2.Lerp(startPosition, finishPosition, (Time.time - startTime) / patrolDuration);

                yield return null;
            }

            yield return new WaitForSeconds(waitDuration);

            StartCoroutine(Patrol(finishPosition, startPosition));

            yield return null;
        }
    }
}
