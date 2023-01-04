using Kutuphane.BusinessLayer.Managers;
using Kutuphane.EntityLayer.Models;
using Kitapcı_Bitmedi.PresentationLayer.Commands;
using Kitapcı_Bitmedi.PresentationLayer.ViewModels.SatisDetayViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Kitapcı_Bitmedi.BusinessLayer.Managers;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.SatisViewModel
{
    public class SatisEkleViewModel : BaseViewModel
    {
        private KitapManager kitapManager;
        private SatisManager satısManager;

        private ObservableCollection<SatisDetayViewModel> items;
        private SatisDetayViewModel selectedItem;
        private string kitapAd = "";
        private decimal toplamTutar = 0;

        public ObservableCollection<SatisDetayViewModel> Items
        {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged();
                }
            }
        }

        public string KitapAd
        {
            get { return kitapAd; }
            set
            {
                if (kitapAd != value)
                {
                    kitapAd = value;
                    OnPropertyChanged();
                }
            }
        }

        public SatisDetayViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal ToplamTutar
        {
            get { return toplamTutar; }
            set
            {
                if (toplamTutar != value)
                {
                    toplamTutar = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand EkleCommand { get; set; }
        public ICommand TamamlaCommand { get; set; }

        public SatisEkleViewModel()
        {
            satısManager = new SatisManager();
            kitapManager = new KitapManager();

            EkleCommand = new RelayCommand(o => { OnEkle(); }, o => { return kitapAd.Length > 2; });
            TamamlaCommand = new RelayCommand(o => { OnTamamla(); }, o => { return items.Count > 0; });
            items = new ObservableCollection<SatisDetayViewModel>();
        }

        private void OnEkle()
        {
            Kitap kitap = kitapManager.Getkitap(kitapAd);
            if (kitap == null)
            {
                MessageBox.Show(kitapAd + " Adlı Kitap yok");
            }
            else
            {
                SatisDetayViewModel detay = items.FirstOrDefault(x => x.Kitap.KitapAd == kitapAd);
                if (detay == null)
                {
                    SatisDetayViewModel item = new SatisDetayViewModel { KitapId = kitap.KitapId, Adet = 1, Tutar = kitap.Fiyat, Kitap = kitap };
                    Items.Add(item);
                }
                else
                {
                    detay.Adet++;
                    detay.Tutar += kitap.Fiyat;
                }
                ToplamTutar += kitap.Fiyat;
            }
            KitapAd = "";
        }

        private void OnTamamla()
        {
            Satis satıs = new Satis() { TarihSaat = DateTime.Now, ToplamTutar = toplamTutar };
            foreach (var item in items)
            {
                SatisDetay detay = new SatisDetay
                {
                    KitapId = item.Kitap.KitapId,
                    Adet = item.Adet,
                    Tutar = item.Tutar
                };
                satıs.Detaylar.Add(detay);
            }

            if (satısManager.Ekle(satıs) > 0)
            {
                Items.Clear();
                ToplamTutar = 0;
            }
            else
            {
                MessageBox.Show("Satış Eklenemedi...");
            }
        }
    }
}
