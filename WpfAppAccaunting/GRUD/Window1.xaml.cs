using System;
using System.Collections.Generic;
using System.Globalization;
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

    public partial class Window1 : Window
    {
        CollectionViewSource skladsViewSource;
        BaseTovarZakaz bas;
        int read;

        public Window1(BaseTovarZakaz bas, int read)
        {
           this.bas = bas;
            this.read = read;

            InitializeComponent();
 
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             skladsViewSource = ((CollectionViewSource)(this.FindResource("skladsViewSource")));
            
            skladsViewSource.Source = bas.sklads.Local;
          skladsViewSource.View.MoveCurrentTo(bas.sklads.Find(read));
          
        }


        private void ButSave_Click_2(object sender, RoutedEventArgs e)
        {
            sklads skld=null;

            DateTime? selectedDate = datapostupDatePicker.DisplayDate;
            try {
            skld = new sklads()
            {
                Datapostup = selectedDate.Value,
                Postavshik = postavshikTextBox.Text,
                Stoimost = decimal.Parse(stoimostTextBox.Text),
                Tovar = tovarTextBox.Text,
                count=Convert.ToInt32 (countTextBox.Text)
            };
           }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
              //Значение ключа в базе меньше нуля, в этом случае добавляется запись,
              //вдругом случае Будет выполнятся редактирование выделенной записи
                if (read <0)
           bas.sklads.Add(skld);
             bas.SaveChanges();

        }

   
    }
}
