using Infra.SqlServer;
using Model;
using Model.Abstraction;
using Model.Version1;

namespace DAL.Repository.SqlServer
{
    public class DepartementRepository : IRepository<IDepartement>
    {
        string choix = "1";
        Crud _implementation;
        public DepartementRepository()
        {
            choix = File.ReadAllText("C:\\temp\\configmodel.txt");
            _implementation = new Crud();
        }
        

        public void Add(IDepartement entity)
        {
            if(choix.Equals(1))
            {
                _implementation.Add_Departement((Departement)entity);
            }
            else
            {
                _implementation.Add_Departement2((Departement2)entity);
            }

        }

        public void Delete(int id)
        {
            if (choix.Equals(1))
            {
                _implementation.Delete_Departement(id);
            }
            else
            {
                _implementation.Delete_Departement2(id);
            }
        }

        public List<IDepartement> FindAll(Predicate<IDepartement> predicate)
        {
            if (choix.Equals(1))
            {
                return _implementation.Filter_Departement(predicate);
            }
            else
            {
                return _implementation.Filter_Departement2(predicate);
            }
        }

        public List<IDepartement> GetAll()
        {
            if (choix.Equals(1))
            {
               return  _implementation.List_Departement();
            }
            else
            {
                return _implementation.List_Departement2();
            }
        }

        public IDepartement GetById(int id)
        {
            if (choix.Equals(1))
            {
                return _implementation.Get_Departement(id);
            }
            else
            {
                return _implementation.Get_Departement(id);
            }
        }

        public void Update(int id, IDepartement newentity)
        {
#pragma warning disable 8604
            if (choix.Equals(1))
            {
                _implementation.Update_Departement(id,newentity as Departement);
            }
            else
            {
                _implementation.Update_Departement2(id,newentity as Departement2);
            }
        }
    }
}
