using DialogEngine.Model;
using System.Collections.Generic;
using System.Linq;

namespace DialogEngine.Engine
{
    public class ConditionManager
    {
        private ConditionEvaluator conditionEvaluator = new ConditionEvaluator();
        private List<Condition> Values { get; set; }


        public ConditionManager(List<Condition> startingConditions)
        {
            Values = startingConditions;
        }

        public void ModifyConditions(List<ConditionModifier> modifiers)
        {
            foreach(var m in modifiers)
            {
                ModifyCondition(m);
            }
        }

        public bool ModifyCondition(ConditionModifier modifier)
        {
            var condition = GetCondition(modifier.Name);

            if (condition == null) return false;

            condition.Value += modifier.Value;

            if (condition.Value < condition.Min) condition.Value = condition.Min;
            if (condition.Value > condition.Max) condition.Value = condition.Max;

            return true;
        }

        public int? GetConditionValue(string name)
        {
            var condition = GetCondition(name);

            if (condition == null) return null;

            return condition.Value;
        }

        private Condition GetCondition(string name)
        {
            return Values.Where(c => c.Name == name).Select(c => c).FirstOrDefault();
        }

        public List<ConditionRequirement> GetFailedRequirements(List<ConditionRequirement> requirements)
        {
            var failed = new List<ConditionRequirement>();

            Condition condition = null;

            foreach(var req in requirements)
            {
                condition = Values.Where(c => c.Name == req.Name).Select(c => c).FirstOrDefault();

                if (!conditionEvaluator.CheckRequirementSuccess(req, condition))
                    failed.Add(req);
            }

            return failed;
        }
    }
}
