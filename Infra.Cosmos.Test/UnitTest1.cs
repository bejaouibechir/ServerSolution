using Infra.CosmosDB;

namespace Infra.Cosmos.Test
{
    public class UnitTest1
    {
        CosmosDBImplementation _implementation;
        public UnitTest1()
        {
            //Intializer la connection
            _implementation = new CosmosDBImplementation();
        }


        [Fact]
        public void AddTest()
        {
            try
            {
                _implementation.Add("entité à ajouter");
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}