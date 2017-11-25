using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfAppAccaunting.model;

namespace WpfAppAccaunting.orders2
{
    /// <summary>
    /// Логика взаимодействия для WindOrder.xaml
    /// </summary>
    public partial class WindOrder : Window
    {
        BaseTovarZakaz _Dbcontext;
        private CollectionViewSource skladsViewSource;
        CollectionViewSource zakaziesViewSource;

        public WindOrder()
        {
            InitializeComponent();
            _Dbcontext = new BaseTovarZakaz();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            SkladLOad();
            ZakazLOad();
        }


        
        void   BtnVozvrat()
        {

            _Dbcontext.sklads.Add(new sklads
            {
                Postavshik = "(Возврат) " + _Dbcontext.zakazies.Find(((zakazies)zakaziesViewSource.View.CurrentItem).Id).Zakazchik,
                Datapostup = DateTime.Now,
                Tovar = _Dbcontext.zakazies.Find(((zakazies)zakaziesViewSource.View.CurrentItem).Id).TovarZ,
                Stoimost = _Dbcontext.zakazies.Find(((zakazies)zakaziesViewSource.View.CurrentItem).Id).Stoimost,
                count = _Dbcontext.zakazies.Find(((zakazies)zakaziesViewSource.View.CurrentItem).Id).CountZ

            });
            _Dbcontext.zakazies.Remove(_Dbcontext.zakazies.Find(((zakazies)zakaziesViewSource.View.CurrentItem).Id));
            _Dbcontext.SaveChanges();
        }

        sklads pointer;
        int otkat = 0;
        private void AddZakaz()
        {
            pointer = (sklads)skladsViewSource.View.CurrentItem;
            otkat = _Dbcontext.sklads.Find(pointer.Id).count;

            try
            {
                zakazies zakaz = new zakazies
                {
                    Zakazchik = ZakazTextBox.Text,
                    TovarZ = tovarTextBox.Text,
                    Datazakaza = DateTime.Now,
                    CountZ = Convert.ToInt32(countTextBox.Text),
                    Stoimost = Convert.ToDecimal(stoimostTextBox.Text)
                };
                _Dbcontext.zakazies.Add(zakaz);
               
                _Dbcontext.sklads.Find(pointer.Id).count = _Dbcontext.sklads.Find(pointer.Id).count - zakaz.CountZ;

            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            ViewSource_Refresh();
        }

        private void ViewSource_Refresh()
        {
            skladsViewSource.View.Refresh();
            zakaziesViewSource.View.Refresh();
        }
        /// <summary>
        ///Данные из Базы: Таблица "sklads"
        /// </summary>
        void SkladLOad() {
            _Dbcontext.sklads.Load();
            skladsViewSource = ((CollectionViewSource)(FindResource("skladsViewSource")));
            skladsViewSource.Source = _Dbcontext.sklads.Local;
        }
        /// <summary>
        ///Данные из Базы: Таблица "zakazies"
        /// </summary>
        void ZakazLOad()
        {
            _Dbcontext.zakazies.Load();
            zakaziesViewSource = ((CollectionViewSource)(FindResource("zakaziesViewSource")));
            zakaziesViewSource.Source = _Dbcontext.zakazies.Local;
        }

     

        private void add_Click(object sender, RoutedEventArgs e)
        {

            //Button btn = (Button)sender;

            //switch (btn.Name)
            //{
            //    case "btnVozvrat": BtnVozvrat(); break;
            //    case "add": AddZakaz(); break;
            //    case "btnCancel":
            //        _Dbcontext = new BaseTovarZakaz();
            //        SkladLOad();
            //        ZakazLOad();
            //        break;

            //    case "btnSave": break;
            //}

        }

        private void StackPanel_GRUD(object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.OriginalSource;

            switch (button.Name)
            {
                case "btnVozvrat": BtnVozvrat(); break;
                case "add": AddZakaz(); break;
                case "btnCancel":
                    _Dbcontext = new BaseTovarZakaz();
                    SkladLOad();
                    ZakazLOad();
                    break;

                case "btnSave": _Dbcontext.SaveChanges(); break;
            }
        }
    }
}
