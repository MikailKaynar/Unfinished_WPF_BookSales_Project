using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.EntityLayer.Models
{
    [Table("tblYazarlar")]
    public class Yazar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YazarId { get; set; }
        [Required]
        public string YazarAd { get; set; }
        [Required]
        public string YazarSoyad { get; set; }
    }
}
