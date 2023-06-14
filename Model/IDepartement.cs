namespace Model.Abstraction
{
    public interface IDepartement
    {
        DateTime CreationDate { get; set; }
        List<IEmployee> Employees { get; set; }
        int Id { get; set; }
        string Label { get; set; }
    }
}