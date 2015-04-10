using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class FullTimeEmployee : Employee
    {
        [Column("SALARY")]
        public int Salary { get; set; }
    }
}
