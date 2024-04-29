using AzureWorkItemAutomation.Builders;
using AzureWorkItemAutomation.Constants;
using AzureWorkItemAutomation.Models;
using AzureWorkItemAutomation.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Factories
{
    public abstract class WorkItemFactory
    {
        protected readonly WorkItemClient _workItemClient;
        protected readonly string _workItemType;

        public abstract BasicWorkItemProperties Details { get; }

        public WorkItemFactory(AzureDevopsServicesClient azureDevopsServicesClient, string workItemType) {
            _workItemClient = new WorkItemClient(azureDevopsServicesClient);
            _workItemType = workItemType;
        }

        public abstract WorkItemCreateResponse Create();

        public WorkItemCreateResponse CreateBasicItem()
        {
            WorkItemBuilder wib = new WorkItemBuilder();
            wib.AddMandatoryBasicFields(Details.title, Details.areaPath, Details.iterationPath);

            return _workItemClient.Create(_workItemType, JsonConvert.SerializeObject(wib.Build()));
        }
    }
}
