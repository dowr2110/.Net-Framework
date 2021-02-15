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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        public List<Zam> std_list = new List<Zam>();
        public List<Zam> std_list3 = new List<Zam>();
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var std = new Zam();
               
                if (Textbox1.Text=="") { throw new Exception("Проверьте ввода Краткое название"); }
                else { std.Kratkoe_nazvaniye = Textbox1.Text; }
                if (Textbox2.Text == "") { throw new Exception("Проверьте ввода Катигория"); }
                else { std.Katigoria = Textbox2.Text; }
                if (Textbox3.Text == "") { throw new Exception("Проверьте ввода Полное описание"); }
                else { std.Polnoe_opisanie = Textbox3.Text; }

                std.datetime = DateTime.Now;
                std.Status = false;
              
                switch (radioButton1.IsChecked)
                {
                    case true when radioButton2.IsChecked == false:
                        std.Preoritet = "Первый";
                        break;
                    case false when radioButton2.IsChecked == true:
                        std.Preoritet = "Второй";
                        break;
                    case false when radioButton2.IsChecked == false:
                        throw new Exception("Необходимо выбрать преоритет");
                }
               
                std_list.Add(std);
               
                MessageBox.Show("Задача сохранена");
                Textbox1.Clear();
                Textbox2.Clear();
                Textbox3.Clear();
                Textbox4.Clear();
                Textbox4.Text =Convert.ToString( std.datetime);
                radioButton1.IsChecked = false;
                radioButton2.IsChecked = false;


                if (std_list.Count != 0)
                    {
                        DataContractJsonSerializer jsonFormatter2 = new DataContractJsonSerializer(typeof(List<Zam>));
                        using (FileStream fs = new FileStream("D:\\фит\\ООП\\2 семестр лабы\\7_8\\doowr.json", FileMode.OpenOrCreate))
                        {
                            if (fs.Length != 0)
                            {
                                std_list3 = (List<Zam>)jsonFormatter2.ReadObject(fs);
                            }
                        }
                        // создаем объект Json
                        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Zam>));
                        // получаем поток, куда будем записывать сериализованный объект

                        for (int i = 0; i < std_list3.Count; i++)
                        {
                            std_list.Add(std_list3[i]);
                        }
                        using (FileStream fs = new FileStream("D:\\фит\\ООП\\2 семестр лабы\\7_8\\doowr.json", FileMode.Create))
                        {
                            jsonFormatter.WriteObject(fs, std_list);

                        
                        }
                        std_list.Clear();
                    }
                    else { throw new Exception("Список пуст"); }
         
            }
            catch (Exception ex)
            {
               MessageBox.Show("Ошибка: " + ex.Message, "Предупреждение!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Textbox1.Clear();
            Textbox2.Clear();
            Textbox3.Clear();

            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
        }
    }
}
