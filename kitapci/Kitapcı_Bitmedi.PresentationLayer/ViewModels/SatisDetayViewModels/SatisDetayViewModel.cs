using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.SatisDetayViewModels
{
    public class SatisDetayViewModel : BaseViewModel
    {
        private SatisDetay _detay;
        public SatisDetay Detay
        {
            get { return _detay; }
        }

        public int SatisDetayId
        {
            get { return _detay.SatisDetayId; }
            set
            {
                if (_detay.SatisDetayId != value)
                {
                    _detay.SatisDetayId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int KitapId
        {
            get { return _detay.KitapId; }
            set
            {
                if (_detay.KitapId != value)
                {
                    _detay.KitapId = value;
                    OnPropertyChanged();
                }
            }
        }

        public Kitap Kitap
        {
            get { return _detay.kitap; }
            set
            {
                if (_detay.kitap != value)
                {
                    _detay.kitap = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Adet
        {
            get { return _detay.Adet; }
            set
            {
                if (_detay.Adet != value)
                {
                    _detay.Adet = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Tutar
        {
            get { return _detay.Tutar; }
            set
            {
                if (_detay.Tutar != value)
                {
                    _detay.Tutar = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SatisId
        {
            get { return _detay.SatisId; }
            set
            {
                if (_detay.SatisId != value)
                {
                    _detay.SatisId = value;
                    OnPropertyChanged();
                }
            }
        }

        public Satis Satis
        {
            get { return _detay.satis; }
            set
            {
                if (_detay.satis != value)
                {
                    _detay.satis = value;
                    OnPropertyChanged();
                }
            }
        }

        public SatisDetayViewModel() : this(new SatisDetay()) { }
        public SatisDetayViewModel(SatisDetay detay)
        {
            this._detay = detay;
        }
    }
}
