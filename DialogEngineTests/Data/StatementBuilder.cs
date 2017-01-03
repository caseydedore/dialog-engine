using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngineTests.Data
{
    public class StatementBuilder
    {
        private NumberGenerator numberGenerator = new NumberGenerator();

        public Statement GetNewStatement(uint id)
        {
            var statement = new Statement();
            statement.ID = id;
            statement.Dialog = Guid.NewGuid().ToString();
            statement.AttitudeID = (uint)numberGenerator.GetRandomInt(0, 100);

            return statement;
        }

        public List<Statement> GetNewStatements(int number = 10)
        {
            var statements = new List<Statement>();

            for(var i = 0; i < number; i++)
            {
                statements.Add(GetNewStatement((uint)i));
            }

            return statements;
        }
    }
}
