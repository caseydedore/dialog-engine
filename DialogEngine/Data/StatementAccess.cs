using DialogEngine.Model;
using System.Collections.Generic;
using System.Linq;

namespace DialogEngine.Data
{
    public class StatementAccess
    {
        public List<Statement> GetStatementsInStatementLink(StatementLink link, List<Statement> statements)
        {
            var ids = link.Links.Select(l => l.StatementID).ToList();

            return statements.Where(s => ids.Any(i => s.ID == i)).ToList();
        }

        public Statement GetStatement(uint statementId, List<Statement> statements)
        {
            return statements.Where(s => s.ID == statementId).Select(s => s).FirstOrDefault();
        }
    }
}
