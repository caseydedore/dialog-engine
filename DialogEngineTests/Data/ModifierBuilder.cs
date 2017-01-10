using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngineTests.Data
{
    public class ModifierBuilder
    {
        private NumberGenerator numberGenerator = new NumberGenerator();


        public ConditionModifier GetNewModifier(uint id)
        {
            var mod = new ConditionModifier();
            mod.Name = Guid.NewGuid().ToString();
            mod.Value = numberGenerator.GetRandomInt();

            return mod;
        }

        public List<ConditionModifier> GetNewModifiers(int number = 10)
        {
            var modifiers = new List<ConditionModifier>();

            for (var i = 0; i < number; i++)
            {
                modifiers.Add(GetNewModifier((uint)i * 2));
            }

            return modifiers;
        }
    }
}
