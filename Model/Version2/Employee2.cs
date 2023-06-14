using Model.Abstraction;

namespace Model
{
    public class Employee2 : IEmployee
    {
        public List<IClient> Clients { get; set; }
        public DateTime CreationDate { get; set; }
        public int DaysOff { get; set; }
        public IDepartement Departement { get; set; }
        public int DepartementId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
