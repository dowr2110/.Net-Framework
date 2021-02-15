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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7.pages
{
    /// <summary>
    /// Логика взаимодействия для home.xaml
    /// </summary>
    public partial class home : Page
    {
       // Model1 db = new Model1();
        public home()
        {
            InitializeComponent();

            //var currentUserId = CurrentUser.GetUserId();
            //var outter = from dict in db.Orders where dict.UserId == currentUserId select dict;//linq
            //var t = outter.FirstOrDefault();
            //if (t.Opovesh ==0)
            //{
            //    opp.Visibility = Visibility.Hidden;
            //}
            //else
            //{
            //    opp.Visibility = Visibility.Visible;
            //}

        }

    }
}



//private readonly Model1 _db = new Model1();
//var currentUserId = CurrentUser.GetUserId();
//var outter = from dict in _db.Orders where dict.UserId==currentUserId select dict;//linq
//liist.DataContext = outter.ToList();
//private void Button_Click(object sender, RoutedEventArgs e)
//{
//    App.MainWindowViewModel.CurrentPage = App.LoginPage;
//}

//private void Button_Click_1(object sender, RoutedEventArgs e)
//{
//    App.AddorderPage = new addorder();
//    App.MainWindowViewModel.CurrentPage = App.AddorderPage;
//}