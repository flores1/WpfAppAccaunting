using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfAppAccaunting.model;
using WpfAppAccaunting.orders2;

namespace WpfAppAccaunting
{

    public partial class MainWindow : Window
    {

        CollectionViewSource skladsViewSource;
        BaseTovarZakaz _base ;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _base = new BaseTovarZakaz();
            LoadSkladsViewSourceBase();
        }

        //добавить, удалить, редактировать в таблице "sklads"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sklads en = (sklads)skladsViewSource.View.CurrentItem;

            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "add":   //Значение ключа в базе меньше нуля(в коллекции ни один эллемент невыбран), добавляется запись,
                    new Window1(_base, -1).ShowDialog();

                    break;

                case "del":
                    _base.sklads.Remove//en.Id указыват на выбранный эллемент, он будет удалён
                        (_base.sklads.Find(en.Id));
                    _base.SaveChanges();
                    break;


                case "read": 
                    new Window1(_base, en.Id).ShowDialog();

                    break;
            }

        }

        //Посмотреть заказы
        private void Zakazy_Click_1(object sender, RoutedEventArgs e)
        {

            new WindOrder().ShowDialog();
            _base = new BaseTovarZakaz();
            LoadSkladsViewSourceBase();
        }

        
        /// <summary>
        ///  Показывает всю таблицу из Базы. 
        ///    (CollectionViewSource) Из базы   данные о товарах в CollectionViewSource --> DataGrid и.д. 
        /// </summary>
        private void LoadSkladsViewSourceBase()
        {
            _base.sklads.Load();
            skladsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("skladsViewSource1")));
            skladsViewSource.Source = _base.sklads.Local;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Печатать таблицу из Базы
        {
            Winreport winreport = new Winreport();
            winreport.ShowDialog();
        }
    }           


}
