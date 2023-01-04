using Kutuphane.DataAccessLayer;
using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.BusinessLayer.Managers
{
    public class KullaniciManager : IDisposable
    {

        private UnitOfWork uow;

        public KullaniciManager()
        {
            uow = new UnitOfWork();
        }

        public bool Login(string eposta, string parola)
        {
            return uow.KullaniciRepo.Login(eposta, parola);
        }

        public List<Kullanici> Listele()
        {
            return uow.KullaniciRepo.GetAll().ToList();
        }

        public Kullanici GetKullanıcı(string eposta)
        {
            return uow.KullaniciRepo.GetItem(eposta);
        }

        public int Ekle(Kullanici kullanıcı)
        {
            if (uow.KullaniciRepo.GetItem(kullanıcı.Eposta) != null)
                throw new ArgumentException(kullanıcı.Eposta + " eposta adresine sahip kullanıcı zaten var");

            uow.KullaniciRepo.Add(kullanıcı);
            return uow.Save();
        }

        public int Sil(string eposta)
        {
            uow.KullaniciRepo.Remove(eposta);
            return uow.Save();
        }

        public int Sil(Kullanici kullanıcı)
        {
            uow.KullaniciRepo.Remove(kullanıcı);
            return uow.Save();
        }

        public int Guncelle(string oldEposta, Kullanici kullanıcı)
        {
            if (kullanıcı.Eposta != oldEposta)
            {
                if (uow.KullaniciRepo.GetItem(kullanıcı.Eposta) != null)
                    throw new ArgumentException(kullanıcı.Eposta + " eposta adresine sahip kullanıcı zaten var...");
            }
            uow.KullaniciRepo.Update(kullanıcı);
            return uow.Save();
        }


        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
