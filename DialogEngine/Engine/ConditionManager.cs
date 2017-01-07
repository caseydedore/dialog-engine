using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngine.Engine
{
    public class ConditionManager
    {
        private List<Condition> Values { get; set; }


        public ConditionManager(List<Condition> startingConditions)
        {
            Values = startingConditions;
        }

        public bool ModifyCondition(string name, int modifier)
        {
            var condition = GetCondition(name);

            if (condition == null) return false;

            condition.Value += modifier;

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
    }
}
