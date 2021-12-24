using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_role")]
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string NameRole { get; set; }
        public virtual ICollection<Accounts_Has_Role> Account_Has_Roles { get; set; }
    }
}
