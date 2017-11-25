using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using WpfAppAccaunting.model;

namespace WpfAppAccaunting.orders
{


    public partial class WindADD : Window
    {
        public event EventHandler Cancel = delegate { };
        CollectionViewSource skladsViewSource;
    public    BaseTovarZakaz bas { get; set; }
        
        public WindADD(BaseTovarZakaz bas)
        {
            this.bas = bas;
            InitializeComponent();
        }        

        
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            bas.sklads.Load();
            skladsViewSource = ((CollectionViewSource)(this.FindResource("skladsViewSource")));
            skladsViewSource.Source = bas.sklads.Local;
            Closed += WindADD_Closed;

        }

        sklads pointer;
        int otkat = 0;
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            pointer = (sklads)skladsViewSource.View.CurrentItem;
            otkat = bas.sklads.Find(pointer.Id).count;
           
            try
            { 
                zakazies zakaz = new zakazies
                {
                    Zakazchik = ZakazchikTextBox.Text,
                    TovarZ = tovarTextBox.Text,
                    Datazakaza = DateTime.Now,
                    CountZ = Convert.ToInt32(countTextBox.Text),
                    Stoimost = Convert.ToDecimal(stoimostTextBox.Text)
                };
                bas.zakazies.Add(zakaz);
                bas.sklads.Find(pointer.Id).count = bas.sklads.Find(pointer.Id).count - zakaz.CountZ;
                
            }  
      
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            skladsViewSource.View.Refresh();
        }
        

        //Отменить в строке
        private void CancelString_Click(object sender, RoutedEventArgs e)
        { 
            //if (pointer == null) return;
            //bas.sklads.Find(pointer.Id).count = otkat;
           
            //skladsViewSource.View.Refresh();
        }
       //ОТМЕНИТЬ ВСЁ
        private void CancelALL_Click(object sender, RoutedEventArgs e)
        {
            Cancel(sender, e);

            //   bas.Dispose();
            //bas = new BaseTovarZakaz();
            //bas.sklads.Load();
         

            //skladsViewSource = ((CollectionViewSource)(this.FindResource("skladsViewSource")));
            //skladsViewSource.Source = bas.sklads.Local;
            Close();
        }
        //Выйти из окна и удалить ссылку на экземпляр объекта
        private void WindADD_Closed(object sender, EventArgs e)
        {
          //bas.Dispose();
        }
        //SAVE
        private void Save_Click(object sender, RoutedEventArgs e)
        {
             bas.SaveChanges();
        }
    }
}
