using Infra.SqlServer;
using Model;

namespace DAL.Repository.SqlServer
{
    public class DepartementRepository : IRepository<Departement>
    {
        Crud _implementation;
        public DepartementRepository() => _implementation = new Crud(); //Bodyed expression 

        public void Add(Departement entity) => _implementation.Add_Departement(entity);

        public void Delete(int id) => _implementation.Delete_Departement(id);


        public List<Departement> FindAll(Predicate<Departement> predicate)
           => _implementation.Filter_Departement(predicate);

        public List<Departement> GetAll()
        => _implementation.List_Departement();

        public Departement GetById(int id)
        => _implementation.Get_Departement(id);

        public void Update(int id, Departement newentity)
        => _implementation.Update_Departement(id, newentity);
    }
}
