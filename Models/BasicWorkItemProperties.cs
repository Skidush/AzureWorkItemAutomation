using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Models
{
    public class BasicWorkItemProperties
    {
        public string? assignedToEmail { get; set; }
        public string areaPath { get; set; }
        public string iterationPath { get; set; }
        public string? state { get; set; }
        public string? description { get; set; }
        public string title { get; set; }
    }   
}
