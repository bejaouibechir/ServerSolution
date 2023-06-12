using Model;
using DAL.Repository;
using DAL.Repository.SqlServer;

namespace DAL.Repository.Test
{
    public class Tests
    {
        IRepository<Employee> _employeeRepository;

        [SetUp]
        public void Setup()
        {
            _employeeRepository = new EmployeeRepository();
        }

        [Test]
        public void AddEmployeeTest()
        {
            Employee employee = new Employee
            {
                Id = 1, Name = "Bechir", DaysOff = 0, Salary = 5500
            };
            _employeeRepository.Add(employee);
            Assert.Pass();
        }
    }
}