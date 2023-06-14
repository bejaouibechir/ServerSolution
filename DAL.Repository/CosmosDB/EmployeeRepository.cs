using Model.Version1;

namespace DAL.Repository.CosmosDB
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> FindAll(Predicate<Employee> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Employee newentity)
        {
            throw new NotImplementedException();
        }
    }
}
