using System;
using System.Collections.Generic;

namespace infra.SqlServer.EF;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal Salary { get; set; }

    public int DaysOff { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? DepartementId { get; set; }

    public virtual Departement? Departement { get; set; }
}
