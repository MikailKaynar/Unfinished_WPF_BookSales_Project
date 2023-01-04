using Kutuphane.DataAccessLayer.Abstract;
using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.DataAccessLayer.Concrete
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(DbContext context) : base(context)
        {
        }

        public bool Login(string Eposta, string Parola)
        {
            return (context.Set<Kullanici>().FirstOrDefault(x => x.Eposta.ToLower().Equals(Eposta) && x.Parola.Equals(Eposta)) != null);
        }

        public new void Add(Kullanici kullanici)
        {
            if (context.Set<Kullanici>().FirstOrDefault(x => x.Eposta.ToLower().Equals(kullanici.Eposta.ToLower())) != null)
                throw new Exception(kullanici.Eposta + " EPosta adresine sahip kullanıcı zaten mevcut");
            else
                context.Set<Kullanici>().Add(kullanici);
        }

        public void Update(string oldEposta, Kullanici kullanıcı)
        {
            if (!oldEposta.ToLower().Equals(kullanıcı.Eposta.ToLower()) && context.Set<Kullanici>().FirstOrDefault(x => x.Eposta.ToLower().Equals(kullanıcı.Eposta.ToLower())) != null)
                throw new Exception(kullanıcı.Eposta + " EPosta adresine sahip kullanıcı zaten mevcut");
            else
            {
                Kullanici item = context.Set<Kullanici>().FirstOrDefault(x => x.Eposta.ToLower().Equals(oldEposta.ToLower()));
                if (item != null)
                {
                    item.Eposta = kullanıcı.Eposta;
                    item.Parola = kullanıcı.Parola;
                }
            }
        }
    }
}
