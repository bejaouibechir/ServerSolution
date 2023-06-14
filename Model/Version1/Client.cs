namespace Model.Version1
{
    //Commentaire
    public class Client : IClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string History { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        //Clé étrangère

        public int EmployeeId { get; set; }

        //Propriété de naviguation
        public Employee Employee { get; set; }


    }
}
