using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp7.pages;
using WpfApp7.ViewModels;
namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindowViewModel MainWindowViewModel { get; set; } = new MainWindowViewModel();
       

        public static home HomePage=new home();
 
        public static addorder AddorderPage;
    
        public static addists Addists;

        public static zapisi ZapisiPage;
 
    }
}
