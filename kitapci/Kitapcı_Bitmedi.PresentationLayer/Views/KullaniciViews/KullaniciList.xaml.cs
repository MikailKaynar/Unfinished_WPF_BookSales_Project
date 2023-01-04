using Kitapcı_Bitmedi.PresentationLayer.ViewModels.KullaniciViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kitapcı_Bitmedi.PresentationLayer.Views.KullaniciViews
{
    /// <summary>
    /// Interaction logic for KullaniciList.xaml
    /// </summary>
    public partial class KullaniciList : Page
    {
        public KullaniciList()
        {
            InitializeComponent();
            DataContext = new KullaniciListViewModel();
        }
    }
}
