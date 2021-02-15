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

namespace lab_7_8_new
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        public List<Zam> std_liist = new List<Zam>();
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
         
            try
            {

                if (std_liist.Count != 0)
                {

                    // создаем объект Json
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Zam>));
                    // получаем поток, куда будем записывать сериализованный объект


                    using (FileStream fs = new FileStream("D:\\фит\\ООП\\2 семестр лабы\\7_8\\doowr.json", FileMode.Create))
                    {
                        jsonFormatter.WriteObject(fs, std_liist);

                        Textbox.Text = "Сохранено "+DateTime.Now;
                       
                    }
                    std_liist.Clear();
                }
                else { throw new Exception("Изменении не было"); }

            }
            catch (Exception ex)
            {
                Textbox.Clear();
                Textbox.Text="Ошибка:  " + ex.Message;
            }
          
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("sdfsdf");
        }
    }
}
