namespace Model
{
    public class Departement
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