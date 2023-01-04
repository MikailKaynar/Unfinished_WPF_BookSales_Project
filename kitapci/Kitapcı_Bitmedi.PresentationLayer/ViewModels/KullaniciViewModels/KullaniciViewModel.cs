using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.KullaniciViewModels
{
    public class KullaniciViewModel : BaseViewModel
    {
        private ObservableCollection<Yetki> yetkiler;
        private Kullanici _kullanici;
        public Kullanici Kullanici
        {
            get { return _kullanici; }
        }

        public string KullaniciAd
        {
            get { return _kullanici.KullaniciAd; }
            set
            {
                if (_kullanici.KullaniciAd != value)
                {
                    _kullanici.KullaniciAd = value;
                    OnPropertyChanged();
                }
            }
        }

        public string KullaniciSoyad
        {
            get { return _kullanici.KullaniciSoyad; }
            set
            {
                if (_kullanici.KullaniciSoyad != value)
                {
                    _kullanici.KullaniciSoyad = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Eposta
        {
            get { return _kullanici.Eposta; }
            set
            {
                if (_kullanici.Eposta != value)
                {
                    _kullanici.Eposta = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Parola
        {
            get { return _kullanici.Parola; }
            set
            {
                if (_kullanici.Parola != value)
                {
                    _kullanici.Parola = value;
                    OnPropertyChanged();
                }
            }
        }

        public Yetki yetki
        {
            get { return _kullanici.Yetki; }
            set
            {
                if (_kullanici.Yetki != value)
                {
                    _kullanici.Yetki = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Yetki> Yetkiler
        {
            get { return yetkiler; }
            set
            {
                if (yetkiler != value)
                {
                    yetkiler = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public KullaniciViewModel() : this(new Kullanici()) { }
        public KullaniciViewModel(Kullanici kullanici)
        {
            this._kullanici = kullanici;
            yetkiler = new ObservableCollection<Yetki> { Kutuphane.EntityLayer.Models.Yetki.Ziyaretci, Kutuphane.EntityLayer.Models.Yetki.Yetkili };
        }
    }
}
