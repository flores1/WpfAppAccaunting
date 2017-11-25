using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfAppAccaunting.model;

namespace WpfAppAccaunting.orders
{

    public partial class WindOrders : Window
    {
       
        CollectionViewSource zakaziesViewSource;
        BaseTovarZakaz _base;

        public WindOrders()  {  InitializeComponent();}
       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _base = new BaseTovarZakaz();
            _base.zakazies.Load();
            zakaziesViewSource = ((CollectionViewSource)(this.FindResource("zakaziesViewSource")));

            zakaziesViewSource.Source = _base.zakazies.Local;// LoadZakazViewSourceBase();

        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            zakazies en = (zakazies)zakaziesViewSource.View.CurrentItem;
            Button btn = (Button)sender;
           
            switch (btn.Name)
            {
                case "add": 
                 var wnd=   new WindADD(_base);
                    wnd.Cancel += Wnd_Cancel;
                    wnd.ShowDialog();
                
                    break;

                case "del":
                     if (en== null) return;
                    _base.zakazies.Remove
                        (_base.zakazies.Find(en.Id));
                    _base.SaveChanges();
                    break;

            }
        }

        private void Wnd_Cancel(object sender, EventArgs e)
        {
           // MessageBox.Show("Отменяю...");
            _base = new BaseTovarZakaz();
            _base.zakazies.Load();
            zakaziesViewSource = ((CollectionViewSource)(this.FindResource("zakaziesViewSource")));
            zakaziesViewSource.Source = _base.zakazies.Local;
            zakaziesViewSource.View.Refresh();

        }


    }
}
