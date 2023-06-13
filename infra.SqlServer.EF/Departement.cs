using System;
using System.Collections.Generic;

namespace infra.SqlServer.EF;

public partial class Departement
{

    public Departement()
    {
        Employees = new HashSet<Employee>();
    }

    public int Id { get; set; }

    public string? Label { get; set; }

    public DateTime? CreationDate { get; set; }

   
    public virtual ICollection<Employee> Employees { get; set; }
}
