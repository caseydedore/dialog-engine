using DialogEngine.EngineModel;
using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngine.Data
{
    public class StatementLinkAccess
    {
        public StatementLink GetStatementLink(uint statementLinkId, List<StatementLink> links)
        {
            return links.Where(l => l.ID == statementLinkId).Select(l => l).FirstOrDefault();
        }

        public uint GetStatementLinkByStatementID(StatementLink link, uint statementId)
        {
            return 
                link.Links.Where(l => l.StatementID == statementId)
                .Select(l => l.NextLinkID)
                .FirstOrDefault();
        }
    }
}
