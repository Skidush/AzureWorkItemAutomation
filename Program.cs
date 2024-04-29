using AzureWorkItemAutomation.Factories;
using AzureWorkItemAutomation.Models;

namespace AzureWorkItemAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AzureDevopsServicesClient httpClient = new AzureDevopsServicesClient("", "https://dev.azure.com/pwc-us-tax-tech/USTaxPlatform/");

            BasicWorkItemProperties props = new BasicWorkItemProperties()
            {
                title = "Rud Test",
                areaPath = @"USTaxPlatform\All Functional Areas\Teams Integration\3Cloud",
                iterationPath = @"USTaxPlatform\FY 2024\FY24 Sprint 22",
                assignedToEmail = "Rud Galangco (US)<rud.galangco@pwc.com>"
            };

            TaskWorkItem sampleTask = new TaskWorkItem(httpClient, props);
            var a = sampleTask.Create();
        }
    }
}