using Kutuphane.BusinessLayer.Managers;
using Kutuphane.EntityLayer.Models;
using Kitapcı_Bitmedi.PresentationLayer.Commands;
using Kitapcı_Bitmedi.PresentationLayer.Views.YayineviViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.YayineviViewModels
{
    public class YayineviListViewModel : BaseViewModel
    {
        private YayineviManager manager;

        private ObservableCollection<YayineviViewModel> _items;
        private YayineviViewModel _selectedItem;

        public ObservableCollection<YayineviViewModel> Items
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

        public YayineviViewModel SelectedItem
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

        public YayineviListViewModel()
        {
            manager = new YayineviManager();
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand((parameter) => { OnDelete(parameter); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand((parameter) => { OnUpdate(parameter); }, o => { return _selectedItem != null; });
        }

        private void OnRefresh()
        {
            Items = new ObservableCollection<YayineviViewModel>();
            List<Yayinevi> yayinevleri = manager.Listele();
            foreach (var item in yayinevleri)
            {
                Items.Add(new YayineviViewModel(item));
            }
        }

        private void OnInsert()
        {
            YayineviViewModel vm = new YayineviViewModel();
            YayineviWindow view = new YayineviWindow() { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Ekle(vm.yayinevi) > 0)
                {
                    Items.Add(vm);
                }
                else
                    MessageBox.Show("Ekleme yapılamadı...");
            }
        }

        private void OnDelete(object parameter)
        {
            YayineviViewModel vm = parameter as YayineviViewModel;
            if (MessageBox.Show(vm.YayineviAd + " adlı Yayınevini silmek istiyor musunuz?", "Yayinevi Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manager.Sil(vm.yayinevi.YayineviId) > 0)
                {
                    Items.Remove(vm);
                }
                else
                    MessageBox.Show("Silinemedi...");
            }
        }

        private void OnUpdate(object parameter)
        {
            YayineviViewModel vm = parameter as YayineviViewModel;
            YayineviWindow view = new YayineviWindow { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Guncelle(vm.yayinevi) == 0)
                    MessageBox.Show("Güncelleme Yapılamadı...");
            }
        }
    }
}
