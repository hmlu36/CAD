using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Dotnet.Models.Enum {
    /// <summary>
    /// 參考: https://forums.asp.net/t/2085611.aspx?Enum+and+Display+Name+
    /// </summary>
    public static class EnumExtensions {
        public static string Code(this System.Enum enu) {
            var attr = GetDisplayAttribute(enu);
            return attr != null ? attr.Name : enu.ToString();
        }

        public static string Description(this System.Enum value) {
            return value.GetType()
                        .GetMember(value.ToString())
                        .FirstOrDefault()
                        ?.GetCustomAttribute<DescriptionAttribute>()
                        ?.Description;
        }

        private static DisplayAttribute GetDisplayAttribute(object value) {
            Type type = value.GetType();
            if (!type.IsEnum) {
                throw new ArgumentException(string.Format("Type {0} is not an enum", type));
            }

            // Get the enum field.
            var field = type.GetField(value.ToString());
            return field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
        }
    }
}
