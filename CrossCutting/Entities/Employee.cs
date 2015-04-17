using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public abstract class Employee
    {

        [Column("ID")]
        [Display(Name="Id")]
        public int Id { get; set; }

        [Column("NAME")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Column("START_DATE")]
        [Display(Name = "Fecha inicial")]
        public DateTime StartDate { get; set; }
    }
}
