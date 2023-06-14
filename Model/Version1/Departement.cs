namespace Model.Version1
{
    public class Departement : IDepartement
    {
        public Departement()
        {
            Employees = new List<Employee>();
        }


        public int Id { get; set; }
        public string Label { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public List<Employee> Employees { get; set; }

    }
}