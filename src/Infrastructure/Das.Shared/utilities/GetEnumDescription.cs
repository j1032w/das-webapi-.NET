using System.ComponentModel;

namespace Das.Shared.utilities;

public class EnumUtilities
{
    public static string GetEnumDescription(Enum value)
    {
        var fi = value.GetType()?.GetField(value.ToString());
        if (fi == null) return "";

        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes.Length > 0)
            return attributes[0].Description;
        return value.ToString();
    }
}
