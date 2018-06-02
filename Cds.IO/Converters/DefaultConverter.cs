using System;
using System.ComponentModel;

namespace Cds.IO.Converters
{
    class DefaultConverter : FieldConverter
    {
        protected override object ConvertCore(Type type, object value)
        {            
            var converter = TypeDescriptor.GetConverter(type);
            return converter.CanConvertFrom(value?.GetType() ?? typeof(object))
                ? converter.ConvertFrom(value)
                : null;            
        }
    }
}
