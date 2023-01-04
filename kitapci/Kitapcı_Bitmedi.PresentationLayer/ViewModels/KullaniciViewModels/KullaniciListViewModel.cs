using Kutuphane.BusinessLayer.Managers;
using Kutuphane.EntityLayer.Models;
using Kitapcı_Bitmedi.PresentationLayer.Commands;
using Kitapcı_Bitmedi.PresentationLayer.Views.KullaniciViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.KullaniciViewModels
{
    public class KullaniciListViewModel : BaseViewModel
    {
        private KullaniciManager manager;

        private ObservableCollection<KullaniciViewModel> items;
        private KullaniciViewModel selectedItem;


        public ObservableCollection<KullaniciViewModel> Items
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

        public KullaniciViewModel SelectedItem
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

        public ICommand RefreshCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public KullaniciListViewModel()
        {
            manager = new KullaniciManager();
            OnRefresh();
            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            UpdateCommand = new RelayCommand((item) => { OnUpdate(item); }, o => { return selectedItem != null; });
            DeleteCommand = new RelayCommand((item) => { OnDelete(item); }, o => { return selectedItem != null; });
        }

        private void OnRefresh()
        {
            Items = new ObservableCollection<KullaniciViewModel>();
            List<Kullanici> kullanicilar = manager.Listele();
            foreach (var item in kullanicilar)
            {
                Items.Add(new KullaniciViewModel(item));
            }
        }

        private void OnInsert()
        {
            KullaniciViewModel vm = new KullaniciViewModel();
            KullaniciWindow dialog = new KullaniciWindow() { DataContext = vm, Title = "Kullanıcı Ekle" };
            if (dialog.ShowDialog() == true)
            {
                if (manager.Ekle(vm.Kullanici) > 0)
                {
                    Items.Add(vm);
                }
                else
                    MessageBox.Show("Ekleme yapılamadı...");
            }
        }
        private void OnUpdate(object item)
        {
            KullaniciViewModel vm = item as KullaniciViewModel;
            string oldEPosta = vm.Kullanici.Eposta;
            KullaniciUpdateWindow view = new KullaniciUpdateWindow { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Guncelle(oldEPosta, vm.Kullanici) == 0)
                    MessageBox.Show("Güncelleme Yapılamadı...");
            }
        }

        private void OnDelete(object item)
        {
            KullaniciViewModel vm = item as KullaniciViewModel;
            if (MessageBox.Show(vm.KullaniciAd + " " + vm.KullaniciSoyad + " İsimli kullanıcıyı silmek istiyor musunuz?", "Kullanıcı Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manager.Sil(vm.Eposta) > 0)
                {
                    Items.Remove(vm);
                }
                else
                    MessageBox.Show("Silinemedi...");
            }
        }
    }
}
