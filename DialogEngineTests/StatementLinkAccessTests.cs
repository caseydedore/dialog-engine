using DialogEngine.Data;
using DialogEngine.Model;
using DialogEngineTests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DialogEngineTests
{
    [TestClass]
    public class StatementLinkAccessTests
    {
        private StatementLinkBuilder builder = new StatementLinkBuilder();
        private StatementBuilder statementBuilder = new StatementBuilder();
        private RequirementBuilder requirementBuilder = new RequirementBuilder();
        private ModifierBuilder modifierBuilder = new ModifierBuilder();
        private StatementLinkAccess access = new StatementLinkAccess();

        private NumberGenerator numberGenerator = new NumberGenerator();


        [TestMethod]
        public void GetStatementLinkTest()
        {
            var links = builder.GetNewStatementLinks();
            var link = links[7];

            var retrievedLink = access.GetStatementLink(link.ID, links);

            Assert.AreEqual(link.ID, retrievedLink.ID);
            Assert.AreEqual(link.Links, retrievedLink.Links);

            for(var i = 0; i < link.Links.Count; i++)
            {
                Assert.AreEqual(link.Links[i].StatementID, retrievedLink.Links[i].StatementID);
                Assert.AreEqual(link.Links[i].NextLinkID, retrievedLink.Links[i].NextLinkID);
            }
        }

        [TestMethod]
        public void GetStatementsInLinkTest()
        {
            var statements = statementBuilder.GetNewStatements(100);
            var statementLink = new StatementLink();

            var statementsInLink = new List<Statement>();

            var link = new Link();

            for (var i = 0; i < 100; i += 10)
            {
                statementsInLink.Add(statements[i]);

                link = new Link()
                {
                    StatementID = statements[i].ID
                };

                statementLink.Links.Add(link);
            }

            var retrievedStatements = access.GetStatements(statementLink, statements);

            Assert.AreEqual(statementsInLink.Count, retrievedStatements.Count);

            for (var i = 0; i < statementsInLink.Count; i++)
            {
                Assert.AreEqual(statementsInLink[i].ID, retrievedStatements[i].ID);
            }
        }

        [TestMethod]
        public void GetNextStatementLinkTest()
        {
            var statements = statementBuilder.GetNewStatements();
            var currentLink = builder.GetNewStatementLink(76);
            var expectedLink = builder.GetNewStatementLink(909);

            var index = 0;
            foreach(var s in statements)
            {
                currentLink.Links.Add(new Link { StatementID = s.ID, NextLinkID = (uint)++index});
            }

            var targetStatement = statements[3];
            currentLink.Links[3].NextLinkID = expectedLink.ID;

            var retrievedLink = access.GetNextLinkIdForStatement(targetStatement.ID, currentLink);

            Assert.AreEqual(expectedLink.ID, retrievedLink);
        }

        [TestMethod]
        public void GetStatementsIdsWithoutRequirements()
        {
            var requirements = requirementBuilder.GetNewRequirements(1);
            var statements = statementBuilder.GetNewStatements(50);
            var validStatements = statements.GetRange(3, 10);
            validStatements.AddRange(statements.GetRange(44, 5));
            var invalidStatements = statements.GetRange(0, 3);
            invalidStatements.AddRange(statements.GetRange(13, 30));
            invalidStatements.Add(statements[49]);
            var link = new StatementLink();
            
            foreach(var s in invalidStatements)
            {
                link.Links.Add(
                    new Link() { StatementID = s.ID, Requirements = new List<ConditionRequirement> { requirements[0] } });
            }

            foreach(var s in validStatements)
            {
                link.Links.Add(new Link(){ StatementID = s.ID });
            }

            var retrievedIds = access.GetStatementIDsWithoutRequirementsMatch(link, requirements);


            Assert.AreEqual(validStatements.Count, retrievedIds.Count);
            for(var i = 0; i < validStatements.Count; i++)
            {
                Assert.AreEqual(validStatements[i].ID, retrievedIds[i]);
            }
        }

        [TestMethod]
        public void GetModifiersForStatementTest()
        {
            var link = builder.GetNewStatementLink(908);
            link.Links.Clear();
            var statements = statementBuilder.GetNewStatements();
            var modifiers = modifierBuilder.GetNewModifiers();

            for (var i = 0; i < statements.Count; i++)
            {
                link.Links.Add(
                    new Link() { StatementID = statements[i].ID, Modifiers = new List<ConditionModifier> { modifiers[i] } });
            }

            var targetStatement = statements[3];
            var targetModifier = link.Links[3].Modifiers[0];

            var retrievedModifiers = access.GetModifiersForStatement(targetStatement.ID, link);


            foreach(var m in retrievedModifiers)
            {
                Assert.AreEqual(targetModifier.Name, m.Name);
                Assert.AreEqual(targetModifier.Value, m.Value);
            }
        }

        [TestMethod]
        public void GetRequirementsForStatementTest()
        {
            var link = builder.GetNewStatementLink(908);
            link.Links.Clear();
            var statements = statementBuilder.GetNewStatements();
            var requirements = requirementBuilder.GetNewRequirements();

            for (var i = 0; i < statements.Count; i++)
            {
                link.Links.Add(
                    new Link() { StatementID = statements[i].ID, Requirements = new List<ConditionRequirement> { requirements[i] } });
            }

            var targetStatement = statements[8];
            var targetRequirement = link.Links[8].Requirements[0];

            var retrievedRequirements = access.GetRequirementsForStatement(targetStatement.ID, link);


            foreach (var r in retrievedRequirements)
            {
                Assert.AreEqual(targetRequirement.Name, r.Name);
                Assert.AreEqual(targetRequirement.Value, r.Value);
            }
        }
    }
}
