using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.EntityLayer.Models
{
    [Table("tblKitaplar")]
    public class Kitap
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KitapId { get; set; }
        public string KitapAd { get; set; }
        public int StokAdet { get; set; }
        public decimal Fiyat { get; set; }

        public int YayineviId { get; set; }
        [ForeignKey("YayineviId")]
        public virtual Yayinevi Yayinevi { get; set; }

        public int YazarId { get; set; }
        [ForeignKey("YazarId")]
        public virtual Yazar Yazar { get; set; }
    }
}
