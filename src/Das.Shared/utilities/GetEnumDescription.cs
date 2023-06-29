using System.ComponentModel;
using System.Reflection;

namespace Das.Shared.utilities
{
    public class EnumUtilities
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo? fi = value.GetType()?.GetField(value.ToString());
            if (fi == null)
            {
                return "";
            }

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }

}