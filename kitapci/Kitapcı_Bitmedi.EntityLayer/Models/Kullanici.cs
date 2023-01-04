using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.EntityLayer.Models
{
    public enum Yetki
    {
        Yetkili = 1,
        Ziyaretci = 2
    }

    [Table("tblKullanicilar")]
    public class Kullanici
    {
        [Key]
        public string Eposta { get; set; }
        [Required]
        public string KullaniciAd { get; set; }
        [Required]
        public string KullaniciSoyad { get; set; }
        [Required]
        public string Parola { get; set; }
        [Required]
        public Yetki Yetki { get; set; }

    }
}
