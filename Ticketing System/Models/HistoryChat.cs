using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_history_chat")]
    public class HistoryChat
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateHistory { get; set; }
        public int IdReply { get; set; }
        public int IdMessage { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual ICollection <Reply> Replys { get; set; }
        public virtual ICollection <Message> Messages { get; set; }
    }
}
