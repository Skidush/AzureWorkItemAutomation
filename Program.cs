using AzureWorkItemAutomation.Factories;

namespace AzureWorkItemAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AzureDevopsServicesClient httpClient = new AzureDevopsServicesClient("", "");
            WorkItemFactory wif = new WorkItemFactory(httpClient, "Product Backlog Item");
            wif.Create();
        }
    }
}