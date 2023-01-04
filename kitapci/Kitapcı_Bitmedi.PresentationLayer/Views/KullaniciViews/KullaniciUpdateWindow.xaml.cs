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

namespace Kitapcı_Bitmedi.PresentationLayer.Views.KullaniciViews
{
    /// <summary>
    /// Interaction logic for KullaniciUpdateWindow.xaml
    /// </summary>
    public partial class KullaniciUpdateWindow : Window
    {
        public KullaniciUpdateWindow()
        {
            InitializeComponent();
        }
        private void btnTamam_Click(object sender, RoutedEventArgs e)
        {
            tbxAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            tbxSoyad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            tbxParola.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cbxYetki.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            DialogResult = true;
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
