using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WpfAppAccaunting
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        ////влияет на культуру. Например из таблицы базы передается точка(символ разделитель), а в интерфейсе отбражается запятая
        // если исп. метод то он приводит к однозначности
        protected override void OnStartup(StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
        new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);
        }
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo("ru"); ;
        //    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru"); ;

        //    FrameworkElement.LanguageProperty.OverrideMetadata(
        //      typeof(FrameworkElement),
        //      new FrameworkPropertyMetadata(
        //            XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

        //    base.OnStartup(e);
        //    }
    }
}
