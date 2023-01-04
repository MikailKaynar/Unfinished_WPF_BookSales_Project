﻿using System;
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

namespace Kitapcı_Bitmedi.PresentationLayer.Views.KitapViews
{
    /// <summary>
    /// Interaction logic for KitapWindow.xaml
    /// </summary>
    public partial class KitapWindow : Window
    {
        public KitapWindow()
        {
            InitializeComponent();
        }
        private void btnTamam_Click(object sender, RoutedEventArgs e)
        {
            tbxAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            tbxFiyat.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            tbxStok.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cbxYayinevi.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            cbxYazar.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            DialogResult = true;
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
