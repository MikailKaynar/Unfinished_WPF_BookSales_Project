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
    public class SatisDetayRepository: Repository<SatisDetay>, ISatisDetayRepository
    {
        public SatisDetayRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SatisDetay> GetAllWithKitap()
        {
            return context.Set<SatisDetay>().Include(x => x.kitap).ToList();
        }

        public IEnumerable<SatisDetay> GetAllWithKitap(int satıs_id)
        {
            return context.Set<SatisDetay>().Include(x => x.kitap).Where(x => x.SatisId == satıs_id).ToList();
        }
    }
}
