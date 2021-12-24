using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_account_has_role")]
    public class Accounts_Has_Role
    {
        [Key]
        public int Id { get; set; }
        public string IdEmployee { get; set; }
        public int IdRole { get; set; }

        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}
