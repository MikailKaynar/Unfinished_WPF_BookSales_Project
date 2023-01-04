using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.EntityLayer.Models
{
    [Table("tblSatislar")]
    public class Satis
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatisId { get; set; }
        public DateTime TarihSaat { get; set; }
        public decimal ToplamTutar { get; set; }

        public ICollection<SatisDetay> Detaylar { get; set; }
        public Satis()
        {
            Detaylar = new List<SatisDetay>();
        }
    }
}
