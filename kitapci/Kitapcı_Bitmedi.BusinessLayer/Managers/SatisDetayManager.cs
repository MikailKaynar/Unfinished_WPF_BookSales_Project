using Kutuphane.DataAccessLayer;
using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.BusinessLayer.Managers
{
    public class SatisDetayManager : IDisposable
    {
        private UnitOfWork uow;
        public SatisDetayManager()
        {
            uow = new UnitOfWork();
        }

        public List<SatisDetay> Listele(int satıs_id)
        {
            return uow.SatısDetayRepo.GetAllWithKitap(satıs_id).ToList();
        }

        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
