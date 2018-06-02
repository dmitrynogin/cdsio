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
        public static IEnumerable<FileSection> Of(Type type, int level) =>
            from property in type.GetProperties()
            let attribute = property.GetCustomAttribute<SectionAttribute>()
            where attribute != null
            orderby property.DeclaringType.GetLevel(), attribute.Order
            select new FileSection(property, attribute, level);

        FileSection(PropertyInfo property, SectionAttribute attribute, int level)
        {
            Property = property;
            Attribute = attribute;
            Level = level;

            if (IsTable && !IsList)
                throw new FormatException($"{Name} table section requires collection property type.");

            if (IsText && !IsString)
                throw new FormatException($"{Name} text section requires string property type.");

            Schema = new FileSchema(Type, level + 1);
        }

        PropertyInfo Property { get; }
        SectionAttribute Attribute { get; }
        public FileSchema Schema { get; }

        public int Level { get; }
        public string Name => Attribute.Name;
        public bool IsText => Attribute is TextAttribute;        
        public bool IsTable => Attribute is TableAttribute;
        public bool IsGroup => IsList && !IsTable;
        
        public object this[object target]
        {
            get => Property.GetValue(target);
            set => Property.SetValue(target, value);
        }

        public object CreateObject() => Activator.CreateInstance(Type);
        public IList CreateList() => (IList)Activator.CreateInstance(
            typeof(List<>).MakeGenericType(Type));

        public Type Type => IsList
            ? Property.PropertyType.GetGenericArguments()[0]
            : Property.PropertyType;

        public bool IsString => Property.PropertyType == typeof(string);
        public bool IsList => 
            !IsString && 
            Property.PropertyType.GetInterfaces().Contains(typeof(IEnumerable));
    }
}
