using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.YazarViewModels
{
    public class YazarViewModel : BaseViewModel
    {
        private Yazar _yazar;
        public Yazar Yazar
        {
            get { return _yazar; }
        }

        public int YazarId
        {
            get { return _yazar.YazarId; }
            set
            {
                if (_yazar.YazarId != value)
                {
                    _yazar.YazarId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string YazarAd
        {
            get { return _yazar.YazarAd; }
            set
            {
                if (_yazar.YazarAd != value)
                {
                    _yazar.YazarAd = value;
                    OnPropertyChanged();
                }
            }
        }

        public string YazarSoyad
        {
            get { return _yazar.YazarSoyad; }
            set
            {
                if (_yazar.YazarSoyad != value)
                {
                    _yazar.YazarSoyad = value;
                    OnPropertyChanged();
                }
            }
        }

        public YazarViewModel() : this(new Yazar()) { }
        public YazarViewModel(Yazar yazar)
        {
            this._yazar = yazar;
        }
    }
}
