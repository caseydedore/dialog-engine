using DialogEngine.Model;
using System;
using System.Collections.Generic;

namespace DialogEngineTests.Data
{
    public class StatementBuilder : ModelBuilder
    {
        public Statement GetNewStatement(uint id)
        {
            var statement = new Statement();
            statement.ID = id;
            statement.Dialog = Guid.NewGuid().ToString();

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
