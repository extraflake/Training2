using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_tracking")]
    public class Tracking
    {
        [Key]
        public int IdTicket { get; set; }
        public DateTime DateProcess { get; set; }
        public string Description { get; set; }
        public DateTime DateSloved { get; set; }
/*        public int IdTicket { get; set; }*/
        public string IdEmployee { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual TechnicalSupport TechnicalSupport { get; set; }
    }
}
