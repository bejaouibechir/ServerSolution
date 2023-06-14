using Model.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Departement2 : IDepartement
    {
        public DateTime CreationDate { get; set; }
        public List<IEmployee> Employees { get; set; }
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
