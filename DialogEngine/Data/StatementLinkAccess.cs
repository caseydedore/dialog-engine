using DialogEngine.Model;
using System.Collections.Generic;
using System.Linq;

namespace DialogEngine.Data
{
    public class StatementLinkAccess
    {
        public StatementLink GetStatementLink(uint statementLinkId, List<StatementLink> links)
        {
            return links.Where(l => l.ID == statementLinkId).Select(l => l).FirstOrDefault();
        }

        public uint GetNextLinkIdForStatement(uint statementId, StatementLink link)
        {
            return 
                link.Links.Where(l => l.StatementID == statementId)
                .Select(l => l.NextLinkID)
                .FirstOrDefault();
        }

        public List<Statement> GetStatements(StatementLink link, List<Statement> statements)
        {
            var ids = link.Links.Select(l => l.StatementID).ToList();

            return statements.Where(s => ids.Any(i => s.ID == i)).ToList();
        }

        public List<uint> GetStatementIdsWithoutRequirements(StatementLink link, List<ConditionRequirement> requirements)
        {
            return 
                link.Links.Where(l => l.Requirement == null || requirements.Any(r => r.Name != l.Requirement.Name))
                .Select(l => l.StatementID).ToList();
        }

        public List<ConditionRequirement> GetRequirementsForStatement(uint statementId, StatementLink link)
        {
            return 
                link.Links.Where(l => l.StatementID == statementId && l.Requirement != null)
                .Select(l => l.Requirement).ToList();
        }

        public List<ConditionModifier> GetModifiersForStatement(uint statementId, StatementLink link)
        {
            return 
                link.Links.Where(l => l.StatementID == statementId && l.Modifier != null)
                .Select(l => l.Modifier).ToList();
        }
    }
}
