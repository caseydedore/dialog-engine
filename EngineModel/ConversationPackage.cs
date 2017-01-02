using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngine.EngineModel
{
    public class ConversationPackage
    {
        public Conversation Conversation { get; set; }
        public List<Actor> Actors { get; set; }
        public List<StatementLink> StatementLinks { get; set; }
        public List<Statement> Statements { get; set; }
        public List<Attitude> Attitudes { get; set; }
    }
}
