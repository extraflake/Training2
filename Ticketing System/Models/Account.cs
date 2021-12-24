using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_account")]
    public class Account
    {
        [Key]
        public string IdEmployee { get; set; }
        public string Password { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Accounts_Has_Role>Accounts_Has_Roles { get; set; }
    }
}
