using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_employee")]
    public class Employee
    {
        [Key]
        public string IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection <Ticket> Tickets { get; set; }
        public virtual Account Account { get; set; }
        public virtual TechnicalSupport TechnicalSupport { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
