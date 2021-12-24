using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_ticket")]
    public class Ticket
    {
        [Key]
        public int IdTicket { get; set; }
        public string StatusTicket { get; set; }
        public DateTime DateRequest { get; set; }
        public string Obtacles { get; set; }
        public string IdEmployee { get; set; }
        public int IdKategori { get; set; }
        public int IdHistoryChat { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Tracking Tracking { get; set; }
        public virtual TechnicalSupport TechnicalSupport { get; set; }
        public virtual Report Report { get; set; }
        public virtual ICollection<HistoryChat> HistoryChats {get; set; }
    }
}
