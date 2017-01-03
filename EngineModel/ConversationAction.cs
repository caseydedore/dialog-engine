using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngine.EngineModel
{
    public class ConversationAction
    {
        public StatementLink CurrentStatementLink { get; set; }
        public Statement ChosenStatement { get; set; }
    }
}
