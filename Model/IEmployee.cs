namespace Model.Abstraction
{
    public interface IEmployee
    {
        List<IClient> Clients { get; set; }
        DateTime CreationDate { get; set; }
        int DaysOff { get; set; }
        IDepartement Departement { get; set; }
        int DepartementId { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        decimal Salary { get; set; }
    }
}