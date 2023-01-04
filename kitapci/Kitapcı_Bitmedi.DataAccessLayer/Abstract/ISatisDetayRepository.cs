using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.DataAccessLayer.Abstract
{
    public interface ISatisDetayRepository : IRepository<SatisDetay>
    {
        IEnumerable<SatisDetay> GetAllWithKitap();
        IEnumerable<SatisDetay> GetAllWithKitap(int satis_id);
    }
}
