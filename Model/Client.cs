namespace Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string History { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    
        //Clé étrangère

        public int EmployeeId { get;set; }
        
        //Propriété de naviguation
        public Employee Employee { get; set; }  
    

    }
}
