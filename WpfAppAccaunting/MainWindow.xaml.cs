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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppAccaunting.model;
namespace WpfAppAccaunting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CollectionViewSource skladsViewSource;
        BaseTovarZakaz _base = new model.BaseTovarZakaz();  
        public MainWindow()
        {
        
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _base.sklads.Load();
            skladsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("skladsViewSource1")));
            
            skladsViewSource.Source = _base.sklads.Local;
           
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            sklads en = (sklads)skladsViewSource.View.CurrentItem;
          
       // skladsDataGrid.ColumnFromDisplayIndex(3).DisplayIndex=1;
            //foreach (DataGridColumn col in skladsDataGrid.Columns)
            //{
            //    //sklads en = (sklads)col.GetCellContent();
            //    //   col.Visibility = Visibility.Visible;
            //    //MessageBox.Show(", " + col.Header.ToString());
            //}
          
            Button btn = (Button)sender;
        
            switch (btn.Name)
            {
                case "add":   //Значение ключа в базе меньше нуля, в этом случае добавляется запись,
                    new Window1(_base,-1).ShowDialog();
                    break;
                    
                               
                   
                case "del":
                    _base.sklads.Remove
                        (_base.sklads.Find(en.Id));
                   _base.SaveChanges();
                    break;                 


                case "read": // Будет выполнятся редактирование выделенной записи по значению ключа
                    new Window1(_base, en.Id).ShowDialog(); 
                   
                    break;

            }

        }

    }

}
