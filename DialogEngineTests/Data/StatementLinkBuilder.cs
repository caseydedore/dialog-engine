using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngineTests.Data
{
    public class StatementLinkBuilder : NumberGenerator
    {
        public StatementLink GetNewStatementLink(uint id, int numberOfChildLinks = 10)
        {
            var link = new StatementLink();
            link.ID = id;

            var childLink = new Link();

            for(var i = 0; i < numberOfChildLinks; i++)
            {
                childLink = new Link()
                {
                    StatementID = (uint)i,
                    NextLinkID = (uint)i * 2,
                    ActorID = (uint)i * 3,
                    //Conditions = 
                };

                link.Links.Add(childLink);
            }

            return link;
        }

        public List<StatementLink> GetNewStatementLinks(int number = 10, int numberOfChildLinks = 10)
        {
            var links = new List<StatementLink>();

            for (var i = 0; i < number; i++)
            {
                links.Add(GetNewStatementLink((uint)i));
            }

            return links;
        }
    }
}
