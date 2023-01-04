using Kutuphane.EntityLayer.Models;
using Kitapcı_Bitmedi.PresentationLayer.Views.KullaniciViews;
using Kitapcı_Bitmedi.PresentationLayer.Views.SatisViews;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kitapcı_Bitmedi.PresentationLayer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Kullanici kullanici { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Window mudurMain = new MainWindow();
            Window ziyaretci = new SatisEkle();

            Login login = new Login();
            if (login.ShowDialog() == true)
            {

                if (kullanici.Yetki == Yetki.Yetkili)
                {
                    MainWindow = mudurMain;
                    ziyaretci.Close();
                }
                else
                {
                    MainWindow = ziyaretci;
                    mudurMain.Close();
                }

                MainWindow.Show();
            }
        }
    }
}
