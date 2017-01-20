using DialogEngine.Model;
using System.Collections.Generic;
using System.Linq;

namespace DialogEngine.Engine
{
    public class ConditionEvaluator
    {
        public bool CheckRequirementSuccess(ConditionRequirement requirement, Condition matchingCondition)
        {
            var result = false;

            switch (requirement.Operator)
            {
                case ">":
                    result = matchingCondition.Value > requirement.Value;
                    break;
                case ">=":
                    result = matchingCondition.Value >= requirement.Value;
                    break;
                case "<":
                    result = matchingCondition.Value < requirement.Value;
                    break;
                case "<=":
                    result = matchingCondition.Value <= requirement.Value;
                    break;
                case "!=":
                    result = matchingCondition.Value != requirement.Value;
                    break;
                case "==":
                case "=":
                    result = matchingCondition.Value == requirement.Value;
                    break;
            }

            return result;
        }
    }
}
