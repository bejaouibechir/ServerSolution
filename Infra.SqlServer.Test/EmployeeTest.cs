using Infra.SqlServer;
using Model.Version1;

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


        [Test]
        public void DeleteTest()
        {
           int id = 2;
           _implementation.Delete_Employee(id);
           Assert.Pass();
        }


        [Test]
        public void GetTest()
        {
            int id = 1;
            Employee employee  = _implementation.Get_Employee(id);
            Assert.Pass();
        }


        [Test]
        public void ListTest()
        {
            var  employees = _implementation.List_Employee();
            Assert.Pass();
        }


        [Test]
        public void FindAllTest()
        {
            var employees = _implementation.Filter_Employee(emp=>emp.Salary<5000 | emp.DaysOff==1);
            Assert.Pass();
        }
    }
}