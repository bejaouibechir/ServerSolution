namespace infra.SqlServer.EF
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Label { get; set; }


        //Propriété qui représente la clé étrangère
        public int? ClientId { get; set; }

        //Propriété de naviguation
        public Client Client { get; set; }


    }
}
