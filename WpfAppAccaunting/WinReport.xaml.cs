using Microsoft.Reporting.WinForms;
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
using System.Collections.Generic;

namespace WpfAppAccaunting
{
    /// <summary>
    /// Логика взаимодействия для Winreport.xaml
    /// </summary>
    public partial class Winreport : Window
    {
        public Winreport()
        {
            InitializeComponent();
            NewMethod();

        
            
        }

        private void NewMethod()
        {
            _reportViewer.Reset();
            model.BaseTovarZakaz products = new model.BaseTovarZakaz();

            List<model.sklads> dt = products.sklads.ToList();

            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            _reportViewer.LocalReport.DataSources.Add(ds);
            _reportViewer.LocalReport.ReportEmbeddedResource = "WpfAppAccaunting.Report1.rdlc";
            _reportViewer.RefreshReport();
        }
    }

}
