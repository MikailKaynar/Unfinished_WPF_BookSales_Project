using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kullanici> Kullanıcılar { get; set; }
        public DbSet<Yayinevi> Yayinevleri { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Satis> Satıslar { get; set; }
        public DbSet<SatisDetay> SatısDetaylar { get; set; }

        public DatabaseContext() : base("name=KutuphaneDbConnStr")
        {
            Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
        }
    }
}
