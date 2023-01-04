using Kitapcı_Bitmedi.PresentationLayer.ViewModels.YazarViewModels;
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

namespace Kitapcı_Bitmedi.PresentationLayer.Views.YazarViews
{
    /// <summary>
    /// Interaction logic for YazarListView.xaml
    /// </summary>
    public partial class YazarListView : Page
    {
        public YazarListView()
        {
            InitializeComponent();
            DataContext = new YazarListViewModel();
        }
    }
}
