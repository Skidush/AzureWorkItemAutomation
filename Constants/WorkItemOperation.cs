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

        [Description("remove")]
        Remove,

        [Description("replace")]
        Replace,

        [Description("move")]
        Move,

        [Description("copy")]
        Copy,

        [Description("Test")]
        Test
    }
}
