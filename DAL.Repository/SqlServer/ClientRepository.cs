using Infra.SqlServer;
using Model;

namespace DAL.Repository.SqlServer
{
    public class ClientRepository : IRepository<Client>
    {
        Crud _implementation;
        public ClientRepository() => _implementation = new Crud(); //Bodyed expression 

        public void Add(Client entity) => _implementation.Add_Client(entity);

        public void Delete(int id) => _implementation.Delete_Client(id);


        public List<Client> FindAll(Predicate<Client> predicate)
           => _implementation.Filter_Client(predicate);

        public List<Client> GetAll()
        => _implementation.List_Client();

        public Client GetById(int id)
        => _implementation.Get_Client(id);

        public void Update(int id, Client newentity)
        => _implementation.Update_Client(id, newentity);
    }
}
