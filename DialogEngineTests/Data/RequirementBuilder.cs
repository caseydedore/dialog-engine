using DialogEngine.Model;
using System;
using System.Collections.Generic;

namespace DialogEngineTests.Data
{
    public class RequirementBuilder
    {
        private NumberGenerator numberGenerator = new NumberGenerator();

        public ConditionRequirement GetNewRequirement(uint id)
        {
            var req = new ConditionRequirement();
            req.Name = Guid.NewGuid().ToString();
            req.Value = numberGenerator.GetRandomInt();

            return req;
        }

        public List<ConditionRequirement> GetNewRequirements(int number = 10)
        {
            var requirements = new List<ConditionRequirement>();

            for(var i = 0; i < number; i++)
            {
                requirements.Add(GetNewRequirement((uint)i * 2));
            }

            return requirements;
        }
    }
}
