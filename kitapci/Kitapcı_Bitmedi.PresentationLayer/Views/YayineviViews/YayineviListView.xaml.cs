using Kitapcı_Bitmedi.PresentationLayer.ViewModels.YayineviViewModels;
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

namespace Kitapcı_Bitmedi.PresentationLayer.Views.YayineviViews
{
    /// <summary>
    /// Interaction logic for YayineviListView.xaml
    /// </summary>
    public partial class YayineviListView : Page
    {
        public YayineviListView()
        {
            InitializeComponent();
            DataContext = new YayineviListViewModel();
        }
    }
}
