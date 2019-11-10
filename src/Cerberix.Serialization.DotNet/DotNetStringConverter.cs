using System;

namespace Cerberix.Serialization.DotNet
{
    public class DotNetStringConverter : IStringConverter
    {
        public string ToString(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return Convert.ToString(value);
        }
    }
}
