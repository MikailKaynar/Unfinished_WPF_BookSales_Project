using Kutuphane.DataAccessLayer.Concrete;
using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.DataAccessLayer 
{
    public class UnitOfWork : IDisposable
    {
        private DatabaseContext context;
        private KullaniciRepository kullanıcıRepo;
        private Repository<Yazar> yazarRepo;
        private Repository<Yayinevi> yayineviRepo;
        private Repository<Satis> satisRepo;
        private SatisDetayRepository satisDetayRepo;
        private KitapRepository kitapRepo;

        public KitapRepository KitapRepo
        {
            get
            {
                if (kitapRepo == null)
                {
                    kitapRepo = new KitapRepository(context);
                }
                return kitapRepo;
            }
        }
        public KullaniciRepository KullaniciRepo
        {
            get
            {
                if (kullanıcıRepo == null)
                {
                    kullanıcıRepo = new KullaniciRepository(context);
                }
                return kullanıcıRepo;
            }
        }

        public Repository<Yazar> YazarRepo
        {
            get
            {
                if (yazarRepo == null)
                {
                    yazarRepo = new Repository<Yazar>(context);
                }
                return yazarRepo;
            }
        }

        public Repository<Yayinevi> YayineviRepo
        {
            get
            {
                if (yayineviRepo == null)
                {
                    yayineviRepo = new Repository<Yayinevi>(context);
                }
                return yayineviRepo;
            }
        }

        public Repository<Satis> SatisRepo
        {
            get
            {
                if (satisRepo == null)
                    satisRepo = new Repository<Satis>(context);
                return satisRepo;
            }
        }

        public SatisDetayRepository SatısDetayRepo
        {
            get
            {
                if (satisDetayRepo == null)
                    satisDetayRepo = new SatisDetayRepository(context);
                return satisDetayRepo;
            }
        }

        public UnitOfWork()
        {
            context = new DatabaseContext();
        }

        public int Save()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int adet = context.SaveChanges();
                    transaction.Commit();
                    return adet;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public void Dispose()
        {
            kullanıcıRepo?.Dispose();
            yazarRepo?.Dispose();
            yayineviRepo?.Dispose();
            kitapRepo?.Dispose();
            context?.Dispose();
            satisRepo?.Dispose();
            satisDetayRepo?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
