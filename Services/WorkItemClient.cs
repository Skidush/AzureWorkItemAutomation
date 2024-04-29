using AzureWorkItemAutomation.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Services
{
    public class WorkItemClient
    {
        private readonly AzureDevopsServicesClient _azureDevopsServicesClient;
        public WorkItemClient(AzureDevopsServicesClient azureDevopsServicesClient)
        {
            _azureDevopsServicesClient = azureDevopsServicesClient;
        }

        public WorkItemCreateResponse Create(string workItemType, string content, bool bypassRules = false)
        {
            StringContent payload = new StringContent(content, null, "application/json-patch+json");

            return _azureDevopsServicesClient.Post<WorkItemCreateResponse>($"/_apis/wit/workitems/${workItemType}?bypassRules={bypassRules}&api-version=7.2-preview.3", payload);
        }
    }
}
