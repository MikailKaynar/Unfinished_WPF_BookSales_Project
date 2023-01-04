using Kutuphane.BusinessLayer.Managers;
using Kutuphane.EntityLayer.Models;
using Kitapcı_Bitmedi.PresentationLayer.Commands;
using Kitapcı_Bitmedi.PresentationLayer.Views.YazarViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.YazarViewModels
{
    public class YazarListViewModel : BaseViewModel
    {
        private YazarManager manager;

        private ObservableCollection<YazarViewModel> _items;
        private YazarViewModel _selectedItem;

        public ObservableCollection<YazarViewModel> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        public YazarViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public YazarListViewModel()
        {
            manager = new YazarManager();
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand((parameter) => { OnDelete(parameter); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand((parameter) => { OnUpdate(parameter); }, o => { return _selectedItem != null; });
        }

        private void OnRefresh()
        {
            Items = new ObservableCollection<YazarViewModel>();
            List<Yazar> yazarlar = manager.Listele();
            foreach (var item in yazarlar)
            {
                Items.Add(new YazarViewModel(item));
            }
        }

        private void OnInsert()
        {
            YazarViewModel vm = new YazarViewModel();
            YazarWindow view = new YazarWindow() { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Ekle(vm.Yazar) > 0)
                {
                    Items.Add(vm);
                }
                else
                    MessageBox.Show("Ekleme yapılamadı...");
            }
        }

        private void OnDelete(object parameter)
        {
            YazarViewModel vm = parameter as YazarViewModel;
            if (MessageBox.Show(vm.YazarAd + " adlı Yazarı silmek istiyor musunuz?", "Yazar Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manager.Sil(vm.Yazar.YazarId) > 0)
                {
                    Items.Remove(vm);
                }
                else
                    MessageBox.Show("Silinemedi...");
            }
        }

        private void OnUpdate(object parameter)
        {
            YazarViewModel vm = parameter as YazarViewModel;
            YazarWindow view = new YazarWindow { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Guncelle(vm.Yazar) == 0)
                    MessageBox.Show("Güncelleme Yapılamadı...");
            }
        }
    }
}
