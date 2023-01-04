using Kutuphane.DataAccessLayer;
using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.BusinessLayer.Managers
{
    public class YayineviManager : IDisposable
    {
        private UnitOfWork uow;

        public YayineviManager()
        {
            uow = new UnitOfWork();
        }

        public List<Yayinevi> Listele()
        {
            return uow.YayineviRepo.GetAll().ToList();
        }

        public Yayinevi GetMarka(int id)
        {
            return uow.YayineviRepo.GetItem(id);
        }

        public int Ekle(Yayinevi yayinevi)
        {
            uow.YayineviRepo.Add(yayinevi);

            return uow.Save();
        }

        public int Sil(int id)
        {
            uow.YayineviRepo.Remove(id);
            return uow.Save();
        }

        public int Guncelle(Yayinevi yayinevi)
        {
            uow.YayineviRepo.Update(yayinevi);
            return uow.Save();
        }

        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
