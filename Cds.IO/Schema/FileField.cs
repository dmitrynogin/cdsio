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
        public static IEnumerable<FileField> Of(object container) =>
            from property in container.GetSimpleType().GetProperties()
            let attribute = property.GetCustomAttribute<FieldAttribute>()
            where attribute != null
            orderby attribute.Order
            select new FileField(container, property, attribute);

        FileField(object container, PropertyInfo property, FieldAttribute attribute)
        {
            Container = container;
            Property = property;
            Attribute = attribute;
        }

        object Container { get; }
        PropertyInfo Property { get; }
        FieldAttribute Attribute { get; }

        public string Name => Attribute.Name;
        public Type Type => Property.PropertyType;

        public object Value
        {
            get => Property.GetValue(Container);
            set => Property.SetValue(Container, value);
        }

        public object this[object obj]
        {
            get => Property.GetValue(obj);
            set => Property.SetValue(obj, value);
        }

        public string Format() =>
            string.Format("{0:" + Attribute.Format + "}", Value);

        public string Format(object obj) =>
            string.Format("{0:" + Attribute.Format + "}", this[obj]);
    }
}
