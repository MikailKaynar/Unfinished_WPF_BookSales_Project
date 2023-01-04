using Kutuphane.DataAccessLayer;
using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.BusinessLayer.Managers
{
    public class YazarManager : IDisposable
    {
        private UnitOfWork uow;

        public YazarManager()
        {
            uow = new UnitOfWork();
        }

        public List<Yazar> Listele()
        {
            return uow.YazarRepo.GetAll().ToList();
        }

        public Yazar GetMarka(int id)
        {
            return uow.YazarRepo.GetItem(id);
        }

        public int Ekle(Yazar yazar)
        {
            uow.YazarRepo.Add(yazar);

            return uow.Save();
        }

        public int Sil(int id)
        {
            uow.YazarRepo.Remove(id);
            return uow.Save();
        }

        public int Guncelle(Yazar yazar)
        {
            uow.YazarRepo.Update(yazar);
            return uow.Save();
        }

        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
