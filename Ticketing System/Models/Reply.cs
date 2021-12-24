using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_reply")]
    public class Reply
    {
        [Key]
        public int IdReply { get; set; }
        public string Replys { get; set; }

        public virtual HistoryChat HistoryChat { get; set; }
    }
}
