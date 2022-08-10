using msa_backend_assignment;
using NUnit.Framework;
using System.Net.Http;

namespace msa_backend_test
{
    public class Tests
    {
        private IHttpClientFactory clientFactory;
        private TrainerDb trainerDb;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllTrainers_ShouldReturnAllTrainers()
        {
            
            PokeController res = new PokeController(clientFactory,trainerDb);
            
            Assert.Pass();
        }
    }
}