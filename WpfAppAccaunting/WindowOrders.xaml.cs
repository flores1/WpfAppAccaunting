using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfAppAccaunting.model;

namespace WpfAppAccaunting
{
    /// <summary>
    /// Логика взаимодействия для WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        model.BaseTovarZakaz _modbase;
        System.Windows.Data.CollectionViewSource zakaziesViewSource;

        public WindowOrders(BaseTovarZakaz modbase)
        {
            _modbase = modbase;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


           zakaziesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("zakaziesViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // zakaziesViewSource.Source = [универсальный источник данных]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "add": _modbase.SaveChanges(); break;

                case "del":
                    zakazies en = (zakazies)zakaziesViewSource.View.CurrentItem;
                    _modbase.zakazies.Remove
                        (_modbase.zakazies.Find(en.Id));
                    _modbase.SaveChanges();
                    break;

                case "read":
                    zakaziesViewSource.View.MoveCurrentToLast();
                    _modbase.SaveChanges();
                    break;

                case "orders":
                    Close();
                    break;

            }
        }


    }
}
