using DialogEngine.Data;
using DialogEngineTests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DialogEngineTests
{
    [TestClass]
    public class ActorAccessTests
    {
        private ActorBuilder builder = new ActorBuilder();
        private ActorAccess access = new ActorAccess();

        [TestMethod]
        public void GetActorByID()
        {
            var actors = builder.GetNewActors();
            var actor = actors[6];

            var retrievedActor = access.GetActor(actor.ID, actors);

            Assert.AreEqual(actor.ID, retrievedActor.ID);
            Assert.AreEqual(actor.Name, retrievedActor.Name);
        }
    }
}
