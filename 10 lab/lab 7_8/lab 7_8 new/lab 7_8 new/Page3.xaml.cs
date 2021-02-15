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

namespace lab_7_8_new
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }
        public List<Zam> stdforsearch = new List<Zam>();
        public List<Zam> std_liiist = new List<Zam>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked==true)
            {
               // phonesGrid.ItemsSource = null;


                stdforsearch.Clear();
                
                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < std_liiist.Count; i++)
                {
                    if (std_liiist[i].Kratkoe_nazvaniye != search_arg)
                    {
                        continue;
                    }
                    else
                    {
                        stdforsearch.Add(std_liiist[i]);
                        c++;
                    }
                }

                if (c == 0) { MessageBox.Show( "Поиск не дал результатов."); phonesGrid.ItemsSource = null; }
                else
                {
                    phonesGrid.ItemsSource = null;
                    phonesGrid.ItemsSource = stdforsearch;
                }
            }
            if (radioButton2.IsChecked == true)
            {
                stdforsearch.Clear();

                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < std_liiist.Count; i++)
                {
                    if (std_liiist[i].Polnoe_opisanie != search_arg)
                    {
                        continue;
                    }
                    else
                    {
                        stdforsearch.Add(std_liiist[i]);
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
            if (radioButton3.IsChecked == true)
            {
                stdforsearch.Clear();

                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < std_liiist.Count; i++)
                {
                    if (std_liiist[i].Katigoria != search_arg)
                    {
                        continue;
                    }
                    else
                    {
                        stdforsearch.Add(std_liiist[i]);
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
            if (radioButton4.IsChecked == true)
            {
                stdforsearch.Clear();

                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < std_liiist.Count; i++)
                {
                    if (std_liiist[i].Preoritet != search_arg)
                    {
                        continue;
                    }
                    else
                    {
                        stdforsearch.Add(std_liiist[i]);
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
            if (radioButton5.IsChecked == true)
            {
                stdforsearch.Clear();

                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < std_liiist.Count; i++)
                {
                    if (std_liiist[i].Datetime != search_arg)
                    {
                        continue;
                    }
                    else
                    {
                        stdforsearch.Add(std_liiist[i]);
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
            if (radioButton6.IsChecked == true)
            {
                stdforsearch.Clear();

                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < std_liiist.Count; i++)
                {
                    if (std_liiist[i].Status2 != search_arg)
                    {
                        continue;
                    }
                    else
                    {
                        stdforsearch.Add(std_liiist[i]);
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

        }
    }
}
