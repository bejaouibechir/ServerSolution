using Model;
using DAL.Repository;
using DAL.Repository.SqlServer;
using DAL.Repository.PostGres;

namespace DAL.Repository.Test
{
    public class DeparetmementRepositoryTest
    {
        IRepository<Departement> _departementRepository;

        [SetUp]
        public void Setup()
        {
            string content = File.ReadAllText("C:\\temp\\config.txt");
            if(content.Equals("1")) { 
              _departementRepository = new SqlServer.DepartementRepository();
            }
            else
            {
               _departementRepository = new PostGres.DepartementRepository();
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