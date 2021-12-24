using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_technical_support")]
    public class TechnicalSupport
    {
        [Key]
        public string IdEmployee { get; set; }
        public int IdTicket { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Tracking Tracking { get; set; }
    }
}
