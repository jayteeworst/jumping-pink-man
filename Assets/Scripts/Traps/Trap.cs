using UnityEngine;

namespace Traps
{
    public abstract class Trap : MonoBehaviour, IDamageInformation
    {
        [SerializeField] protected TrapType trapType;
        [EnumConditionalField("trapType", TrapType.Damaging)]
        [SerializeField] [Range(1f, 10f)] protected int damageAmount;
        [SerializeField] protected float knockbackForce = 1000f;

        protected void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent<Player.Player>(out var player)) return;
            PlayerCollided(player);
            if (trapType == TrapType.Instakill) return;
            player.Knockback(-other.GetContact(0).normal, knockbackForce);
        }

        protected abstract void PlayerCollided(Player.Player player);

        protected enum TrapType
        {
            Damaging,
            Instakill
        }

        public DamageInformation DamageInfo => new()
        {
            DamageSourceName = name,
            DamageAmount = damageAmount
        };
    }

#if UNITY_EDITOR
    public class EnumConditionalFieldAttribute : PropertyAttribute
    {
        public string enumFieldName;
        public object enumValue;

        public EnumConditionalFieldAttribute(string enumFieldName, object enumValue)
        {
            this.enumFieldName = enumFieldName;
            this.enumValue = enumValue;
        }
    }

    [UnityEditor.CustomPropertyDrawer(typeof(EnumConditionalFieldAttribute))]
    public class EnumConditionalFieldDrawer : UnityEditor.PropertyDrawer
    {
        public override void OnGUI(Rect position, UnityEditor.SerializedProperty property, GUIContent label)
        {
            EnumConditionalFieldAttribute enumCondition = attribute as EnumConditionalFieldAttribute;

            if (enumCondition != null)
            {
                UnityEditor.SerializedProperty enumField = property.serializedObject.FindProperty(enumCondition.enumFieldName);

                if (enumField != null)
                {
                    if (enumField.enumValueIndex == (int)enumCondition.enumValue)
                    {
                        UnityEditor.EditorGUI.PropertyField(position, property, label, true);
                    }
                }
                else
                {
                    UnityEditor.EditorGUI.LabelField(position, label.text, "Enum field not found");
                }
            }
        }
    }
#endif
}