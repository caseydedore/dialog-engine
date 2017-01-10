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
                link.Links.Where(l => requirements.Except(l.Requirements).Any())
                .Select(l => l.StatementID).ToList();
        }

        public List<ConditionRequirement> GetRequirements(StatementLink link)
        {
            return
                link.Links.SelectMany(l => l.Requirements).ToList();
        }

        public List<ConditionRequirement> GetRequirementsForStatement(uint statementId, StatementLink link)
        {
            return 
                link.Links.Where(l => l.StatementID == statementId)
                .SelectMany(l => l.Requirements).ToList();
        }

        public List<ConditionModifier> GetModifiersForStatement(uint statementId, StatementLink link)
        {
            return 
                link.Links.Where(l => l.StatementID == statementId)
                .SelectMany(l => l.Modifiers).ToList();
        }
    }
}
