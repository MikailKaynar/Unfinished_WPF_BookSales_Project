using Kutuphane.DataAccessLayer;
using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.BusinessLayer.Managers
{
    public class SatisManager : IDisposable
    {
        private UnitOfWork uow;
        public SatisManager()
        {
            uow = new UnitOfWork();
        }

        public List<Satis> Listele()
        {
            return uow.SatisRepo.GetAll().ToList();
        }

        public int Ekle(Satis satıs)
        {
            foreach (var detay in satıs.Detaylar)
            {
                Kitap kitap = uow.KitapRepo.GetItem(detay.KitapId);
                kitap.StokAdet -= detay.Adet;
                uow.KitapRepo.Update(kitap);
            }
            uow.SatisRepo.Add(satıs);
            return uow.Save();
        }

        public int Sil(int id)
        {
            uow.SatisRepo.Remove(id);
            return uow.Save();
        }

        public int Sil(Satis satis)
        {
            uow.SatisRepo.Remove(satis);
            return uow.Save();
        }

        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
