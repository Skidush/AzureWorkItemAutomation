using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Constants
{
    public enum WorkItemOperation
    {
        [Description("add")]
        Add,

        [Description("update")]
        Update,

        [Description("delete")]
        Delete
    }

    public static class WorkItemActionExtensions
    {
        public static string Value(this WorkItemOperation action)
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
