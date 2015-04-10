using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class PartTimeEmployee : Employee
    {
        [Required]
        
        [Column("RATE")]
        public double HourlyRate { get; set; }
    }
}
