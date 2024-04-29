using AzureWorkItemAutomation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Constants
{
    public enum WorkItemPath
    {
        [Description("/fields/System.Title")]
        Title,

        [Description("/fields/System.AreaPath")]
        AreaPath,

        [Description("/fields/System.IterationPath")]
        IterationPath,

        [Description("/fields/System.AssignedTo")]
        AssignedTo,

        [Description("/fields/System.Tags")]
        Tags,

        [Description("/fields/System.State")]
        State
    }
}
