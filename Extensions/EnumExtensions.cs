using AzureWorkItemAutomation.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Extensions
{
    public static class EnumExtensions
    {
        public static string Value<T>(this T action) where T : Enum
        {
            FieldInfo field = action.GetType().GetField(action.ToString());

            if (field != null)
            {
                DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return action.ToString();
        }
    }
}
