using System;
using System.ComponentModel;
using System.Reflection;

namespace passportApp.Common
{
    public class Enums
    {
        public enum GenderType
        {
            [Description("Male")]
            M,
            [Description("Female")]
            F
        }
    }

    public static class Util
    {
        public static T StringToEnum<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }

        public static string ToDescriptionString(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}