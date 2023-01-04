using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.DataAccessLayer.Abstract
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        bool Login(string Eposta, string Parola);
    }
}
