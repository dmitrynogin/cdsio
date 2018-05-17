using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Schema
{
    class FileField
    {
        public static IEnumerable<FileField> Of(Type type) =>
            from property in type.GetProperties()
            let attribute = property.GetCustomAttribute<FieldAttribute>()
            where attribute != null
            orderby attribute.Order
            select new FileField(property, attribute);

        FileField(PropertyInfo property, FieldAttribute attribute)
        {
            Property = property;
            Attribute = attribute;
        }

        PropertyInfo Property { get; }
        FieldAttribute Attribute { get; }

        public string Name => Attribute.Name;
        public Type Type => Property.PropertyType;

        public object this[object target]
        {
            get => Property.GetValue(target);
            set => Property.SetValue(target, value);
        }

        public string Format(object target) =>
            string.Format("{0" + 
                (Attribute.Width == 0 ? "": "," + Attribute.Width) +
                (Attribute.Format == "" ? "" : ":" + Attribute.Format) +
                "}", this[target]);
    }
}
