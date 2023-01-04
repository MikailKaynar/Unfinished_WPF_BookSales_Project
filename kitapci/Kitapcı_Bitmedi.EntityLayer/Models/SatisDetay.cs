using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.EntityLayer.Models
{
    public class SatisDetay
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatisDetayId { get; set; }
        public int SatisId { get; set; }
        [ForeignKey("SatisId")]
        public Satis satis { get; set; }

        public int KitapId { get; set; }
        [ForeignKey("KitapId")]
        public Kitap kitap { get; set; }
        public int Adet { get; set; }
        public decimal Tutar { get; set; }
    }
}
