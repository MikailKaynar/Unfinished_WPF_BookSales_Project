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
using System.Windows.Shapes;

namespace Kitapcı_Bitmedi.PresentationLayer.Views.YazarViews
{
    /// <summary>
    /// Interaction logic for YazarWindow.xaml
    /// </summary>
    public partial class YazarWindow : Window
    {
        public YazarWindow()
        {
            InitializeComponent();
        }

        private void btnTamam_Click(object sender, RoutedEventArgs e)
        {
            tbxAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            tbxSoyad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            DialogResult = true;
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
