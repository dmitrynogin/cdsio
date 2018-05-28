using System;

namespace Cds.IO.Schema
{
    static class InheritanceLevel
    {
        public static int GetLevel(this Type type, int level = 1) =>
            type.BaseType == typeof(object) ? level : type.BaseType.GetLevel(level + 1);
    }
}
