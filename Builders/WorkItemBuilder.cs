using AzureWorkItemAutomation.Constants;
using AzureWorkItemAutomation.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

        public WorkItemBuilder AddWorkItemField(WorkItemField workItemField)
        {
            _workItemFields.Add(workItemField);

            return this;
        }

        public WorkItemBuilder AddWorkItemFields(WorkItemOperation operation, List<WorkItemPathValuePair> workItemPathValues)
        {
            workItemPathValues.ForEach(pathValuePair =>
            {
                _workItemFields.Add(new WorkItemFieldBuilder().Build(operation, pathValuePair.path, pathValuePair.value));
            });

            return this;
        }

        public WorkItemBuilder AddMandatoryBasicFields(string title, string areaPath, string iterationPath)
        {
            List<WorkItemPathValuePair> workItemPathValuePairs = new List<WorkItemPathValuePair>()
            {
                new WorkItemPathValuePair() { path = WorkItemPath.Title, value = title },
                new WorkItemPathValuePair() { path = WorkItemPath.AreaPath, value = areaPath },
/*                new WorkItemPathValuePair() { path = WorkItemPath.IterationPath, value = iterationPath }*/
            };

            this.AddWorkItemFields(WorkItemOperation.Add, workItemPathValuePairs);

            return this;
        }

        public WorkItemBuilder AddAssigneeField(WorkItemOperation operation, string assigneeEmail)
        {
            _workItemFields.Add(new WorkItemFieldBuilder().Build(operation, WorkItemPath.AssignedTo, assigneeEmail));

            return this;
        }

        public List<WorkItemField> Build()
        {
            return _workItemFields;
        }
    }
}