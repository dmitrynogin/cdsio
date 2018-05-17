using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Schema
{
    static class ListType
    {
        public static Type GetSimpleType(this object obj) => obj.GetType()
            .GetSimpleType();

        public static Type GetSimpleType(this Type type) => type.IsList()
            ? type.GetGenericArguments()[0]
            : type;

        public static bool IsList(this Type type) => 
            type.GetInterfaces().Contains(typeof(IEnumerable));
    }
}
