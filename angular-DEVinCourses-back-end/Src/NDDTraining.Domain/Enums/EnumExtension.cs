using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Enums
{
    public static class EnumExtension
    {
        public static string GetName(this Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              ?.GetCustomAttribute<DisplayAttribute>()
              ?.GetName();

            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }

        public static TEnum ConvertEnum<TEnum>(this string status) where TEnum : Enum
        {
            return (TEnum)Enum.Parse(typeof(TEnum), status);
        }
    }
}
