using Infra.SqlServer;
using Model;

namespace Infra.SqlServer.Test
{
    public class Tests
    {
        Crud _implementation;
        
        [SetUp]
        public void Setup()
        {
            //Ouvrir la connection à SQL Server
            _implementation = new Crud();
        }

        [Test]
        public void AddTest()
        {
            try
            {
                Employee employee = new Employee
                {
                    Id = 2,
                    Name = "Employee1",
                    DaysOff = 10,
                    Salary = 5500
                };
                _implementation.Add_Employee(employee);
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

    }
}