using DialogEngine.Model;
using System.Collections.Generic;
using System.Linq;

namespace DialogEngine.Engine
{
    public class ConditionEvaluator
    {
        public bool CheckRequirementSuccess(ConditionRequirement requirement, Condition matchingCondition)
        {
            var result = true;

            switch (requirement.Operator)
            {
                case ">":
                    result = requirement.Value > matchingCondition.Value;
                    break;
                case ">=":
                    result = requirement.Value >= matchingCondition.Value;
                    break;
                case "<":
                    result = requirement.Value < matchingCondition.Value;
                    break;
                case "<=":
                    result = requirement.Value <= matchingCondition.Value;
                    break;
                case "!=":
                    result = requirement.Value != matchingCondition.Value;
                    break;
            }

            return result;
        }
    }
}
