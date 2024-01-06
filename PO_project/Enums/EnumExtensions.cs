using System.ComponentModel;

namespace PO_project.Enums
{
    public static class EnumExtensions
    {
        public static string GetEnumLabel(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute?.Description ?? value.ToString();
        }
    }
}
