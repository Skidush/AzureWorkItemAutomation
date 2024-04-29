using AzureWorkItemAutomation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Models
{
    public class WorkItemField
    {
        public string op { get; set; }
        public string path { get; set; }
        public object? from { get; set; }
        public string? value { get; set; }

    }

    public class WorkItemPathValuePair
    {
        public WorkItemPath path { get; set; }
        public string? value { get; set; }
    }
}
