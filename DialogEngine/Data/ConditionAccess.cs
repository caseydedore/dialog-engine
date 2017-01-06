using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngine.Data
{
    public class ConditionAccess
    {
        public Condition GetCondition(uint id, List<Condition> conditions)
        {
            return conditions.Where(c => c.ID == id).Select(c => c).FirstOrDefault();
        }
    }
}
