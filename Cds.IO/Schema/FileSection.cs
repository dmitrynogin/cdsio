using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cds.IO.Schema
{
    class FileSection
    {
        public static IEnumerable<FileSection> Of(object container, int level) =>
            from property in container.GetType().GetProperties()
            let attribute = property.GetCustomAttribute<SectionAttribute>()
            where attribute != null
            orderby attribute.Order
            select new FileSection(container, property, attribute, level);

        FileSection(object container, PropertyInfo property, SectionAttribute attribute, int level)
        {
            Container = container;
            Property = property;
            Attribute = attribute;
            Level = level;
            if (IsList)
                List = List ?? CreateList();
            else
                Object = Object ?? CreateObject();

            Schema = new FileSchema(Object, level + 1);
        }

        object Container { get; }
        PropertyInfo Property { get; }
        SectionAttribute Attribute { get; }
        public FileSchema Schema { get; }

        public int Level { get; }
        public string Name => Attribute.Name;

        public object Object
        {
            get => Property.GetValue(Container);
            private set => Property.SetValue(Container, value);
        }

        public IList List
        {
            get => Object as IList;
            private set => Object = value;
        }

        public object CreateObject() => Activator.CreateInstance(Type);
        public IList CreateList() => (IList)Activator.CreateInstance(
            typeof(List<>).MakeGenericType(Type));

        Type Type => Property.PropertyType.GetSimpleType();
        public bool IsList => Property.PropertyType.IsList();
    }
}
