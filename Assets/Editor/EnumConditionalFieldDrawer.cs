using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(EnumConditionalFieldAttribute))]
    public class EnumConditionalFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumConditionalFieldAttribute enumCondition = attribute as EnumConditionalFieldAttribute;

            SerializedProperty enumField = property.serializedObject.FindProperty(enumCondition.enumFieldName);

            if (enumField != null)
            {
                if (enumField.enumValueIndex == (int)enumCondition.enumValue)
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Enum field not found");
            }
        }
    }
}