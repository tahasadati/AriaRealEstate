using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace AriaRealState.Data.Helps.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        if (enumValue == null)
            return string.Empty;

        var memberInfo = enumValue
            .GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault();

        if (memberInfo == null)
            return enumValue.ToString();

        var displayAttribute = memberInfo
            .GetCustomAttribute<DisplayAttribute>();

        return displayAttribute?.Name ?? enumValue.ToString();
    }
}
