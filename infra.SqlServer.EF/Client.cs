using System;
using System.Collections.Generic;

namespace infra.SqlServer.EF;

public partial class Client
{

    public Client()
    {
        Invoices = new HashSet<Invoice>();
     }

    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? History { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set;}
}
