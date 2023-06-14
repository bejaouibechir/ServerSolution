

namespace Model.Abstraction
{
    public interface IClient
    {
        DateTime CreationDate { get; set; }
        IEmployee Employee { get; set; }
        int EmployeeId { get; set; }
        string History { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}