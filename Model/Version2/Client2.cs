using Model.Abstraction;

namespace Model
{
    public class Client2 : IClient
    {
        public DateTime CreationDate { get; set; }
        public IEmployee Employee { get; set; }
        public int EmployeeId { get; set; }
        public string History { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
