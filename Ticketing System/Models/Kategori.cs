using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_System.Models
{
    [Table("tb_kategori")]
    public class Kategori
    {
        [Key]
        public int IdKategori { get; set; }
        public string NamaKategori { get; set; }
        public string IdEmployee { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual TechnicalSupport TechnicalSupport { get; set; }

    }
}
