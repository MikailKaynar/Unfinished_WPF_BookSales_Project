using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.YayineviViewModels
{
    public class YayineviViewModel : BaseViewModel
    {
        private Yayinevi _yayinevi;
        public Yayinevi yayinevi
        {
            get { return _yayinevi; }
        }

        public int Id
        {
            get { return _yayinevi.YayineviId; }
            set
            {
                if (_yayinevi.YayineviId != value)
                {
                    _yayinevi.YayineviId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string YayineviAd
        {
            get { return _yayinevi.YayineviAd; }
            set
            {
                if (_yayinevi.YayineviAd != value)
                {
                    _yayinevi.YayineviAd = value;
                    OnPropertyChanged();
                }
            }
        }

        public YayineviViewModel() : this(new Yayinevi()) { }
        public YayineviViewModel(Yayinevi yayinevi)
        {
            this._yayinevi = yayinevi;
        }
    }
}
