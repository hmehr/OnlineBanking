using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSE6260.OnlineBanking.Infrastructure.Domain
{
    [Serializable]
    public abstract class EntityBase
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        protected virtual void Validate()
        {

        }

        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        public string GetValidationMessage()
        {
            if (GetBrokenRules().Count() == 0) return String.Empty;
            var brokenRules = new StringBuilder();
            foreach (var businessRule in GetBrokenRules())
                brokenRules.AppendLine(businessRule.Rule);
            return brokenRules.ToString();
        }
    }
}
