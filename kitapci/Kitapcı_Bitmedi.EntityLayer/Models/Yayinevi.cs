using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.EntityLayer.Models
{
    [Table("tblYayinevleri")]
    public class Yayinevi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YayineviId { get; set; }
        [Required]
        public string YayineviAd { get; set; }
    }
}
