using DAL.Repository;
using DAL.Repository.SqlServer;
using DAL.Repository.PostGres;
using Model.Version1;
using Model.Abstraction;

namespace DAL.Repository.Test
{
    public class DeparetmementRepositoryTest
    {
        IRepository<IDepartement> _departementRepository;

        [SetUp]
        public void Setup()
        {
            string content = File.ReadAllText("C:\\temp\\config.txt");
            if(content.Equals("1")) { 
              _departementRepository = new SqlServer.DepartementRepository();
            }
            else
            {
                //Travail à faire: adapter le DDD pour qu'il implémente DAO voir comme exemple 
                //les modfications faites au niveau de DepartementRepository et CRUD 
                //On ajouté deux versions pour chacune des methodes crud exemple
                //Get_Departement qui gère l'entité Departement et Get_Departement2 qui gère Departement2 
                

                //_departementRepository = new PostGres.DepartementRepository();
            }

        }
        

        [Test]
        public void AddDepartementTest()
        {
            Departement departement = new Departement
            {
                Id = 1, Label="Direction générale"
            };
            _departementRepository.Add(departement);
            Assert.Pass();
        }
        [Test]
        public void UpdateDepartementTest()
        {
            int id = 1;
            
            Departement departement = new Departement
            {
                Id = 1,
                Label = "Direction Générale"
            };
            _departementRepository.Update(id,departement);
            Assert.Pass();
        }

        [Test]
        public void GetDepartementTest()
        {
            int id = 1;
            Departement departement = _departementRepository.GetById(id);
            Assert.Pass();
        }

        [Test]
        public void ListDepartementTest()
        {
            var departement = _departementRepository.GetAll();
            Assert.Pass();
        }

        [Test]
        public void FilterDepartementTest()
        {
            var departement = _departementRepository.FindAll(dep=>dep.Label=="Direction Générale");
            Assert.Pass();
        }

        [Test]
        public void DeleteDepartementTest()
        {
            int id = 1;
            _departementRepository.Delete(id);
            Assert.Pass();
        }

    }
}