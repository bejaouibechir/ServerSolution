using Model;

namespace DAL.Repository.SqlServer
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public void Add(Employee entity)
        {
            ;
            ;
            ;
        }

        public void Delete(int id)
        {
            ;
        }

        public List<Employee> FindAll(Predicate<Employee> predicate)
        {
             return null;
        }

        public List<Employee> GetAll()
        {
            return null;
        }

        public Employee GetById(int id)
        {
            return null;
        }

        public void Update(int id, Employee newentity)
        {
           ;
        }
    }
}
