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
    public class WorkItemFactory
    {
        private readonly AzureDevopsServicesClient _httpClient;
        private readonly string _workItemType;

        public WorkItemFactory(AzureDevopsServicesClient client, string workItemType) {
            string api_version = "api-version=7.2-preview.3"; // Update, call from config
            _httpClient = client;
            _workItemType = workItemType;
        }

        public void Create()
        {
            /*new WorkItemPathValuePair() { path = "/fields/System.Title", value = "Product Backlog Item: Hello from my work item automation test!" },
            new WorkItemPathValuePair() { path = "/fields/System.AreaPath", value = "Quality Engineering (QE)" },
            new WorkItemPathValuePair() { path = "/fields/System.IterationPath", value = "Quality Engineering (QE)\\Sprint 1" }*/

            /*new WorkItemPathValuePair() { path = "/fields/System.Title", value = "Hello from my work item automation test!" },
            new WorkItemPathValuePair() { path = "/fields/System.AreaPath", value = "USTaxPlatform\\All Functional Areas\\Teams Integration\\3Cloud" },
            new WorkItemPathValuePair() { path = "/fields/System.IterationPath", value = "USTaxPlatform\\FY 2024\\FY24 Sprint 22" }*/

            List<WorkItemPathValuePair> workItemPathValuePairs = new List<WorkItemPathValuePair>()
            {
                new WorkItemPathValuePair() { path = "/fields/System.Title", value = "Hello from my work item automation test!" },
                new WorkItemPathValuePair() { path = "/fields/System.AreaPath", value = "USTaxPlatform\\All Functional Areas\\Teams Integration\\3Cloud" },
                new WorkItemPathValuePair() { path = "/fields/System.IterationPath", value = "USTaxPlatform\\FY 2024\\FY24 Sprint 22" }
            };

            WorkItemBuilder wib = new WorkItemBuilder();
            wib.AddWorkItemFields(WorkItemOperation.Add, workItemPathValuePairs);

            StringContent payload = new StringContent(JsonConvert.SerializeObject(wib.Build()), null, "application/json-patch+json");

            WorkItemCreateResponse a = _httpClient.Post<WorkItemCreateResponse>($"/_apis/wit/workitems/${_workItemType}?api-version=7.2-preview.3", payload);
        }
    }
}
