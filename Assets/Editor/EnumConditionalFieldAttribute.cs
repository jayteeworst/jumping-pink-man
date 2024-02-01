using UnityEngine;

namespace Editor
{ 
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
}