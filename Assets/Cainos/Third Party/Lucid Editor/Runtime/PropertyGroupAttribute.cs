using System;
using System.Linq;

namespace Cainos.LucidEditor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PropertyGroupAttribute : Attribute
    {
        public readonly string path;
        public readonly string name;
        public readonly int groupDepth;

        public PropertyGroupAttribute(string groupPath)
        {
            path = groupPath;
            name = path.Split('/').Last();
            groupDepth = path.Count(x => x == '/');
        }
    }
}