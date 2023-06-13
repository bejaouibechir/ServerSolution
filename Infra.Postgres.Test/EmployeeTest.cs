using Model;

namespace Infra.Postgres.Test
{
    public class Tests
    {
        Crud _implementation;
        
        [SetUp]
        public void Setup()
        {
            _implementation = new Crud();
        }

        [Test]
        public void AddTest()
        {
            try
            {
                Employee employee = new Employee
                {
                    Id = 1,
                    Name = "EmployeeXYX",
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