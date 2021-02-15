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
using System.Runtime.Serialization.Json;
using System.IO;
using System.Globalization;
using System.Windows.Markup;

namespace lab_7_8_new
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public List<Zam> std_list2 = new List<Zam>();
        public List<Zam> sortStdList = new List<Zam>();
        public List<Zam> empty = new List<Zam>();
        public List<Zam> stdforsearch = new List<Zam>();
        //  public List<Zam> StdListforsort = new List<Zam>();
        public MainWindow()
        {
            this.Language = XmlLanguage.GetLanguage(App.Language.IetfLanguageTag);
            InitializeComponent();
            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;
            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }


           // -------------------------------------------------------------------

            CommandBinding CBinding = new CommandBinding();

            ///////////////////////////
            /// // устанавливаем команду
            CBinding.Command = ApplicationCommands.Open;
            // устанавливаем метод, который будет выполняться при вызове команды
            CBinding.Executed += ExecuteMethod;
            // добавляем привязку к коллекции привязок элемента Button
            vyvod.CommandBindings.Add(CBinding);
            ///////////////////////////////
            ///
            List<string> styles = new List<string> { "dark", "light", "red" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "dark";

        }
        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;
            this.Language = XmlLanguage.GetLanguage(App.Language.IetfLanguageTag);
            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }

        private void ExecuteMethod(Object sender,ExecutedRoutedEventArgs e)
        {
            fraam.Content = null;
        }


        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }


        public Page2 pg2 = new Page2();
        public Page3 pg3 = new Page3();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         // fraam.NavigationService.Navigate(new Uri("Page1.xaml", UriKind.RelativeOrAbsolute));
           
            fraam.Content = new Page1();
        }
        
        private void Fraam_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
   
        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        { 

            try
            {
                pg2.std_liist.Clear();
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Zam>));

                using (FileStream fs = new FileStream("D:\\фит\\ООП\\2 семестр лабы\\7_8\\doowr.json", FileMode.OpenOrCreate))
                {
                    if (fs.Length != 0)
                    {
                        std_list2 = (List<Zam>)jsonFormatter.ReadObject(fs);

                        Textbox.Text = Convert.ToString(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);

                    }
                    else
                    {
                        throw new Exception("JSON файл отсутствует или пуст.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            phonesGrid.ItemsSource = null;
            phonesGrid.ItemsSource = std_list2;
            for (int i = 0; i < std_list2.Count; i++)
            {
                pg2.std_liist.Add(std_list2[i]);
            }
            for (int i = 0; i < std_list2.Count; i++)
            {
                pg3.std_liiist.Add(std_list2[i]);
            }

            pg2.phonesGrid.ItemsSource = null;
            pg2.phonesGrid.ItemsSource = pg2.std_liist;
           
         
        }

        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            fraam.Content = null;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            fraam.Content = null;
            fraam.Content = pg2;
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Combo.SelectedIndex == 0)
            {
                sortStdList.Clear();
                var sort_variable = from i in std_list2
                                    orderby i.Kratkoe_nazvaniye
                                    select i;
                foreach (var s in sort_variable)
                {
                    sortStdList.Add(s);
                }
                phonesGrid.ItemsSource = null;
                phonesGrid.ItemsSource = sortStdList;
            }
            else if (Combo.SelectedIndex == 1)
            {
                sortStdList.Clear();
                var sort_variable = from i in std_list2
                                    orderby i.Polnoe_opisanie
                                    select i;
                foreach (var s in sort_variable)
                {
                    sortStdList.Add(s);
                }
                phonesGrid.ItemsSource = null;
                phonesGrid.ItemsSource = sortStdList;
            }
            else if (Combo.SelectedIndex == 2)
            {
                sortStdList.Clear();
                var sort_variable = from i in std_list2
                                    orderby i.Katigoria
                                    select i;
                foreach (var s in sort_variable)
                {
                    sortStdList.Add(s);
                }
                phonesGrid.ItemsSource = null;
                phonesGrid.ItemsSource = sortStdList;
            }
            else if (Combo.SelectedIndex == 3)
            {
                sortStdList.Clear();
                var sort_variable = from i in std_list2
                                    orderby i.Preoritet
                                    select i;
                foreach (var s in sort_variable)
                {
                    sortStdList.Add(s);
                }
                phonesGrid.ItemsSource = null;
                phonesGrid.ItemsSource = sortStdList;
            }
            else if (Combo.SelectedIndex == 4)
            {
                sortStdList.Clear();
                var sort_variable = from i in std_list2
                                    orderby i.Datetime
                                    select i;
                foreach (var s in sort_variable)
                {
                    sortStdList.Add(s);
                }
                phonesGrid.ItemsSource = null;
                phonesGrid.ItemsSource = sortStdList;
            }
            else if (Combo.SelectedIndex == 5)
            {
                sortStdList.Clear();
                var sort_variable = from i in std_list2
                                    orderby i.Status2
                                    select i;
                foreach (var s in sort_variable)
                {
                    sortStdList.Add(s);
                }
                phonesGrid.ItemsSource = null;
                phonesGrid.ItemsSource = sortStdList;
            }
            else
            {
                phonesGrid.ItemsSource = null;
            }
           


        }

        private void Textbooox_TextChanged(object sender, TextChangedEventArgs e)
        {
   
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            fraam.Content = null;
            fraam.Content = pg3;
        }

        private void MenuLanguage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
         
        }
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar1.SelectedDate;

            
            stdforsearch.Clear();
           
            string search_arg = selectedDate.Value.Date.ToShortDateString();
         
               var c = 0;
                for (var i = 0; i < std_list2.Count; i++)
                {
                string g = std_list2[i].Datetime;
                g = g.Substring(0, g.Length - 9);//sozlemi kiceltmek
                if (g != search_arg)
                    {
                        continue;
                    }
                    else
                    {
                        stdforsearch.Add(std_list2[i]);
                        c++;
                    }
                }


                if (c == 0) { MessageBox.Show("Поиск не дал результатов."); phonesGrid.ItemsSource = null; }
                else
                {
                    phonesGrid.ItemsSource = null;
                    phonesGrid.ItemsSource = stdforsearch;
                }
            
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Window1 wnm = new Window1();
            wnm.Show();
        }

        //private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
        //    {
        //        writer.WriteLine("Выход из приложения: " + DateTime.Now.ToShortDateString() + " " +
        //        DateTime.Now.ToLongTimeString());
        //        writer.Flush();
        //    }

        //    this.Close();
        //}

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("Вызов команды: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }
            MessageBox.Show(" Это новая комнада");
        }

        private void Button_Click_9()
        {

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {

        }
    }

    public class NewCustomCommand
    {
        private static RoutedUICommand pnvCommand;
        static NewCustomCommand()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.P, ModifierKeys.Alt, "Alt+P"));
            pnvCommand = new RoutedUICommand("PNV", "PNV", typeof(NewCustomCommand), inputs);
        }
        public static RoutedUICommand PnvCommand
        {
            get
            {
                return pnvCommand;
            }
        }
    }
        //public class WindowCommands
        //{
        //    static WindowCommands()
        //    {
        //        Exit = new RoutedCommand("Exit", typeof(MainWindow));
        //    }
        //    public static RoutedCommand Exit { get; set; }
        //}
    }
