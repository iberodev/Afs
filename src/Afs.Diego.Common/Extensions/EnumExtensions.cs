using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Afs.Diego.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName<T>(this T enumType) where T : struct, IConvertible
        {
            FieldInfo fieldInfo = enumType.GetType().GetField(enumType.ToString());
            DisplayAttribute[] displayAttributes = (DisplayAttribute[])
                fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (displayAttributes.Length > 0)
            {
                return displayAttributes[0].Name;
            }
            return enumType.ToString();
        }
    }
}
