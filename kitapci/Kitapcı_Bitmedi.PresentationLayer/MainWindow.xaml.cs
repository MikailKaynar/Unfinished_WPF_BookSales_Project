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

namespace Kitapcı_Bitmedi.PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnYazarList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/YazarViews/YazarListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnYayineviList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/YayineviViews/YayineviListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnKitapList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/KitapViews/KitapList.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnKullaniciList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/KullaniciViews/KullaniciList.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnSatisList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/SatisViews/SatisList.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }
    }
}
