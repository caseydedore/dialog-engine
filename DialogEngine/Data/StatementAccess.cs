using DialogEngine.Model;
using System.Collections.Generic;
using System.Linq;

namespace DialogEngine.Data
{
    public class StatementAccess
    {
        public Statement GetStatement(uint statementId, List<Statement> statements)
        {
            return statements.Where(s => s.ID == statementId).Select(s => s).FirstOrDefault();
        }

        public List<Statement> GetStatements(List<uint> statementIds, List<Statement> statements)
        {
            return statements.Where(s => statements.Any(st => st.ID == s.ID)).ToList();
        }
    }
}
