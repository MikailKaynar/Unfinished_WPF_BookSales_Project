using Kutuphane.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapcı_Bitmedi.PresentationLayer.ViewModels.SatisDetayViewModels
{
    public class SatisDetayListViewModel : BaseViewModel
    {
        private ObservableCollection<SatisDetay> items;
        private SatisDetay selectedItem;

        public ObservableCollection<SatisDetay> Items
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

        public SatisDetay SelectedItem
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

        public SatisDetayListViewModel(List<SatisDetay> detaylar)
        {
            Items = new ObservableCollection<SatisDetay>(detaylar);
        }
    }
}
