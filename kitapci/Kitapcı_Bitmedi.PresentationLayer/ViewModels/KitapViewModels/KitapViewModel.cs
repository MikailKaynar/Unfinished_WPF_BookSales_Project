using Kutuphane.BusinessLayer.Managers;
using Kutuphane.EntityLayer.Models;
using Kitapcı_Bitmedi.PresentationLayer.ViewModels.YayineviViewModels;
using Kitapcı_Bitmedi.PresentationLayer.ViewModels.YazarViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.KitapViewModels
{
    public class KitapViewModel : BaseViewModel
    {
        private Kitap _kitap;
        public Kitap Kitap
        {
            get { return _kitap; }
        }


        public int KitapId
        {
            get { return _kitap.KitapId; }
            set
            {
                if (_kitap.KitapId != value)
                {
                    _kitap.KitapId = value;
                    OnPropertyChanged();
                }
            }
        }


        public string KitapAd
        {
            get { return _kitap.KitapAd; }
            set
            {
                if (_kitap.KitapAd != value)
                {
                    _kitap.KitapAd = value;
                    OnPropertyChanged();
                }
            }
        }

        public int StokAdet
        {
            get { return _kitap.StokAdet; }
            set
            {
                if (_kitap.StokAdet != value)
                {
                    _kitap.StokAdet = value;
                    OnPropertyChanged();
                }
            }
        }


        public decimal Fiyat
        {
            get { return _kitap.Fiyat; }
            set
            {
                if (_kitap.Fiyat != value)
                {
                    _kitap.Fiyat = value;
                    OnPropertyChanged();
                }
            }
        }

        private YazarViewModel _yazar;
        public YazarViewModel Yazar
        {
            get { return _yazar; }
            set
            {
                if(_yazar != value)
                {
                    _yazar = value;
                    OnPropertyChanged();
                }
            }
        }

        private YayineviViewModel _yayinevi;
        public YayineviViewModel Yayinevi
        {
            get { return _yayinevi; }
            set
            {
                if (_yayinevi != value)
                {
                    _yayinevi = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Yazar> yazarlar;
        public ObservableCollection<Yazar> Yazarlar
        {
            get { return yazarlar; }
            set
            {
                if (yazarlar != value)
                {
                    yazarlar = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Yayinevi> yayinevleri;
        public ObservableCollection<Yayinevi> Yayinevleri
        {
            get { return yayinevleri; }
            set
            {
                if (yayinevleri != value)
                {
                    yayinevleri = value;
                    OnPropertyChanged();
                }
            }
        }


        public KitapViewModel() : this(new Kitap()) { }
        public KitapViewModel(Kitap kitap)
        {
            this._kitap = kitap;
            this._yayinevi = new YayineviViewModel(kitap.Yayinevi);
            this._yazar = new YazarViewModel(kitap.Yazar);

            using (YayineviManager manager = new YayineviManager())
            {
                Yayinevleri = new ObservableCollection<Yayinevi>(manager.Listele());
            }
            using (YazarManager manager = new YazarManager())
            {
                Yazarlar = new ObservableCollection<Yazar>(manager.Listele());
            }
        }

    }
}
