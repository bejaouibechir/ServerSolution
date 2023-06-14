using Model.Version1;

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

        [Test]
        public void UpdateTest()
        {
           //Ajouter le test de mise à jour
        }

        [Test]
        public void DeleteTest()
        {
            //Ajouter le test de supression
        }

        [Test]
        public void GetTest()
        {
            //Ajouter le test pour avoir un employee
        }

        [Test]
        public void ListTest()
        {
            //Ajouter le test pour lister les employees
        }

        [Test]
        public void FiltreTest()
        {
            //Ajouter le test pour filter les employees
        }

    }
}