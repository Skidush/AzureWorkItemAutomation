using AzureWorkItemAutomation.Constants;
using AzureWorkItemAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Builders
{
    public class WorkItemBuilder
    {
        private readonly List<WorkItemField> _workItemFields = new List<WorkItemField>();

        public WorkItemBuilder() {

        }

        public void AddWorkItemField(WorkItemField workItemField)
        {
            _workItemFields.Add(workItemField);
        }

        public void AddWorkItemFields(WorkItemOperation operation, List<WorkItemPathValuePair> workItemPathValues)
        {
            workItemPathValues.ForEach(pathValuePair =>
            {
                _workItemFields.Add(new WorkItemFieldBuilder().Build(operation, pathValuePair.path, pathValuePair.value));
            });
        }

        public List<WorkItemField> Build()
        {
            return _workItemFields;
        }
    }
}
