using Infra.Postgres;
using Model;

namespace DAL.Repository.PostGres
{
    public class EmployeeRepository : IRepository<Employee>
    {
        Crud _implementation;
        public EmployeeRepository() => _implementation = new Crud(); //Bodyed expression 

        public void Add(Employee entity) => _implementation.Add_Employee(entity);

        public void Delete(int id) => _implementation.Delete_Employee(id);


        public List<Employee> FindAll(Predicate<Employee> predicate)
           => _implementation.Filter_Employee(predicate);

        public List<Employee> GetAll()
        => _implementation.List_Employee();

        public Employee GetById(int id)
        => _implementation.Get_Employee(id);

        public void Update(int id, Employee newentity)
        => _implementation.Update_Employee(id, newentity);
    }
}
