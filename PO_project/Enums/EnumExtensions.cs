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

        //public static bool IsPodstawowy(this Matura subject)
        //{
        //    var fieldInfo = typeof(Matura).GetField(subject.ToString());
        //    var attribute = (SubjectTypeAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(SubjectTypeAttribute));

        //    return attribute?.Type == SubjectTypeEnum.Podstawowy;
        //}
    }
}
