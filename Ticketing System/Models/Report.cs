using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_report")]
    public class Report
    {
        [Key]
        public int IdReport { get; set; }
        public int IdTicket { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
