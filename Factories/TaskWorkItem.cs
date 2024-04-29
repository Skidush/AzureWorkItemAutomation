using AzureWorkItemAutomation.Builders;
using AzureWorkItemAutomation.Constants;
using AzureWorkItemAutomation.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Factories
{
    public class TaskWorkItem : WorkItemFactory
    {
        public override BasicWorkItemProperties Details { get; }

        public TaskWorkItem(AzureDevopsServicesClient client, BasicWorkItemProperties workItemDetails) : base(client, "Task")
        {
            Details = workItemDetails;
        }

        public override WorkItemCreateResponse Create()
        {
            WorkItemBuilder wib = new WorkItemBuilder();
            wib.AddMandatoryBasicFields(Details.title, Details.areaPath, Details.iterationPath);

            if (Details.assignedToEmail != null)
            {
                wib.AddAssigneeField(WorkItemOperation.Add, Details.assignedToEmail);

            }

            string json = JsonConvert.SerializeObject(wib.Build()).Replace(@"\\", @"\");

            return this._workItemClient.Create(_workItemType, json);
        }
    }
}
