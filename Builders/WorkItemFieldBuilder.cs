using AzureWorkItemAutomation.Constants;
using AzureWorkItemAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkItemAutomation.Builders
{
    public class WorkItemFieldBuilder
    {
        private readonly WorkItemField _workItemField = new WorkItemField();

        public WorkItemFieldBuilder()
        {

        }

        public void SetOperation(WorkItemOperation operation)
        {
            _workItemField.op = operation.Value();
        }

        public void SetPath(string path)
        {
            _workItemField.path = path;
        }

        public void SetValue(string? value)
        {
            _workItemField.value = value;
        }

        public void SetFrom(string? fromValue)
        {
            _workItemField.from = fromValue;
        }

        public WorkItemField Build()
        {
            return _workItemField;
        }

        public WorkItemField Build(WorkItemOperation operation, string path, string? value = null, string? from = null)
        {
            SetOperation(operation);
            SetPath(path);
            SetValue(value);
            SetFrom(from);

            return _workItemField;
        }
    }
}
