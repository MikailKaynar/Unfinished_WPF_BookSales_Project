using Kutuphane.DataAccessLayer;
using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapcı_Bitmedi.BusinessLayer.Managers
{
    public class KitapManager : IDisposable
    {
        private UnitOfWork uow;
        public KitapManager()
        {
            uow = new UnitOfWork();
        }

        public List<Kitap> Listele()
        {
            return uow.KitapRepo.GetAllWithYazar_Yayinevi().ToList();
        }

        public Kitap Getkitap(int id)
        {
            return uow.KitapRepo.GetAllWithYazar_Yayinevi(id);
        }
        public Kitap Getkitap(string kitapAd)
        {
            return uow.KitapRepo.GetAllWithYazar_Yayinevi(kitapAd);
        }

        public int Ekle(Kitap kitap)
        {
            if (uow.KitapRepo.GetAllWithYazar_Yayinevi(kitap.KitapAd) != null)
                throw new ArgumentException(kitap.KitapAd + " İsimli Kitap zaten var...");
            uow.KitapRepo.Add(kitap);
            return uow.Save();
        }

        public int Sil(int id)
        {
            uow.KitapRepo.Remove(id);
            return uow.Save();

        }
        public int Sil(Kitap kitap)
        {
            uow.KitapRepo.Remove(kitap);
            return uow.Save();
        }

        public int Guncelle(string eskiKitapAd, Kitap kitap)
        {
            if (kitap.KitapAd != eskiKitapAd)
            {
                if (uow.KitapRepo.GetAllWithYazar_Yayinevi(kitap.KitapAd) != null)
                    throw new ArgumentException(kitap.KitapAd + " İsimli kitap zaten var...");
            }
            uow.KitapRepo.Update(kitap);
            return uow.Save();
        }

        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
