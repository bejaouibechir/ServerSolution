namespace Model
{
    public class Employee
    {
        public Employee()
        {
            Clients = new List<Client>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; } 

        public int  DaysOff { get; set; }
   
        public DateTime CreationDate { get; set; } = DateTime.Now;

        //Clé étrangère 

        public int  DepartementId { get; set;}

        //Propriété de naviguation 
        public Departement Departement { get; set; }  
        

        public List<Client> Clients { get; set;}

    }
}
