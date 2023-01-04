using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.DataAccessLayer.Abstract
{
    public interface IKitapRepository : IRepository<Kitap>
    {
        IEnumerable<Kitap> GetAllWithYazar_Yayinevi();
        Kitap GetAllWithYazar_Yayinevi(string kitapAd);
        Kitap GetAllWithYazar_Yayinevi(int id);
    }
}
