using System;
using System.Collections.Generic;

namespace infra.SqlServer.EF;

public partial class Client
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? History { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
