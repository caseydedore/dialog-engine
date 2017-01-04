using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngineTests.Data
{
    public class ActorBuilder : ModelBuilder
    {
        public Actor GetNewActor(uint id)
        {
            var actor = new Actor();
            actor.ID = id;
            actor.Name = Guid.NewGuid().ToString();

            return actor;
        }

        public List<Actor> GetNewActors(int numberOfActors = 10)
        {
            var actors = new List<Actor>();

            for (var i = 0; i < numberOfActors; i++)
            {
                actors.Add(GetNewActor((uint)i));
            }

            return actors;
        }
    }
}
