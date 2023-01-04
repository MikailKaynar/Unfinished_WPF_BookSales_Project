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
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        public KitapRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Kitap> GetAllWithYazar_Yayinevi()
        {
            return context.Set<Kitap>().Include(x => x.Yazar)
                                       .Include(x => x.Yayinevi).ToList();
        }

        public Kitap GetAllWithYazar_Yayinevi(string kitapAd)
        {
            return context.Set<Kitap>().Include(x => x.Yazar)
                                       .Include(x => x.Yayinevi).ToList().FirstOrDefault(x => x.KitapAd.Equals(kitapAd));
        }

        public Kitap GetAllWithYazar_Yayinevi(int id)
        {
            return context.Set<Kitap>().Include(x => x.Yazar)
                                       .Include(x => x.Yayinevi).ToList().FirstOrDefault(x => x.KitapId.Equals(id));
        }

        
    }
}
