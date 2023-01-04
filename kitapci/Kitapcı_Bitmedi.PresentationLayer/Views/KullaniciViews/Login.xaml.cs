using Kutuphane.BusinessLayer.Managers;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (KullaniciManager manager = new KullaniciManager())
            {
                if (manager.Login(tbxEposta.Text, tbxPassword.Password))
                {
                    App.kullanici = manager.GetKullanıcı(tbxEposta.Text);
                    DialogResult = true;
                }
            }
        }

    }
}
