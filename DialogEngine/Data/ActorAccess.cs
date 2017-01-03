using DialogEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngine.Data
{
    public class ActorAccess
    {
        public Actor GetActor(uint actorId, List<Actor> actors)
        {
            return actors.Where(a => a.ID == actorId).Select(a => a).FirstOrDefault();
        }
    }
}
