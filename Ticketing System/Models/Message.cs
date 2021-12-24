using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_message")]
    public class Message
    {
        [Key]
        public int IdMessage { get; set; }
        public string Messages { get; set; }

        public virtual HistoryChat HistoryChat { get; set; }
    }
}
