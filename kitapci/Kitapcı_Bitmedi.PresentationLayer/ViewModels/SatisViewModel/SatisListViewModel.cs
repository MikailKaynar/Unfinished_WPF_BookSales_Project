using Kutuphane.BusinessLayer.Managers;
using Kutuphane.EntityLayer.Models;
using Kitapcı_Bitmedi.PresentationLayer.Commands;
using Kitapcı_Bitmedi.PresentationLayer.ViewModels.SatisDetayViewModels;
using Kitapcı_Bitmedi.PresentationLayer.Views.SatisDetayViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.SatisViewModel
{
    public class SatisListViewModel : BaseViewModel
    {
        private ObservableCollection<Satis> items;
        private Satis selectedItem;

        public ObservableCollection<Satis> Items
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

        public Satis SelectedItem
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
        public ICommand DetayCommand { get; set; }

        public SatisListViewModel()
        {
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            DetayCommand = new RelayCommand((parameter) => { OnDetay(parameter); }, (parameter) => { return parameter != null; });
        }

        private void OnRefresh()
        {
            using (SatisManager manager = new SatisManager())
            {
                Items = new ObservableCollection<Satis>(manager.Listele());
            }
        }

        private void OnDetay(object parameter)
        {
            Satis satıs = parameter as Satis;
            using (SatisDetayManager manager = new SatisDetayManager())
            {
                SatisDetayListViewModel vm = new SatisDetayListViewModel(manager.Listele(satıs.SatisId));
                SatisDetayListView view = new SatisDetayListView() { DataContext = vm };
                view.Show();
            }
        }
    }
}
