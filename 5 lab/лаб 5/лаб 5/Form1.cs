using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace лаб_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<Scet> std_list = new List<Scet>();
        public List<Scet> std_list2 = new List<Scet>();
        public List<Scet> std_list3 = new List<Scet>();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var std = new Scet(new Vladelec());
               // var regex1 = new Regex(@"^[A-ZА-Я][a-zа-я]{1,200}$");
                if ( textBox1.Text == ""){ throw new Exception("Проверьте ввода Фамилии"); }
                else { std.Vladelec.Family_name = textBox1.Text; }
                if ( textBox2.Text == "") { throw new Exception("Проверьте формат ввода Имени"); }
                else { std.Vladelec.Name = textBox2.Text; }
                if ((textBox3.Text=="")) { throw new Exception("Проверьте ввода Отчества"); }
                else { std.Vladelec.Otcest = textBox3.Text; } 
                std.Vladelec.Date_of_birth = dateTimePicker1.Text;
                if (textBox4.Text.Length==8) { std.Vladelec.Pasportno = Convert.ToInt32(textBox4.Text); }
                else { throw new Exception("Проверьте ввода Паспорт№(должно быть 8 символов)"); }
                if (textBox5.Text=="") { throw new Exception("Проверьте ввода Персонального№"); }
                else { std.Vladelec.Personalno = Convert.ToInt32(textBox5.Text); }
                if ( textBox6.Text == "") { throw new Exception("Проверьте ввода Место рождения"); }
                else { std.Vladelec.Place_of_birth = textBox6.Text; }
                switch (radioButton1.Checked)
                {
                    case true when radioButton2.Checked == false:
                        std.Vladelec.Sex = "Пол женский";
                        break;
                    case false when radioButton2.Checked == true:
                        std.Vladelec.Sex = "Пол мужской";
                        break;
                    case false when radioButton2.Checked == false:
                        throw new Exception("Необходимо выбрать пол");
                }
                if (textBox7.Text == "") { throw new Exception("Проверьте ввода Номера"); }
                else { std.Nomer = Convert.ToInt32(textBox7.Text); }
                if (comboBox1.Text == "") { throw new Exception("Выберите Тип вклада"); }
                else { std.Tip_vklada = comboBox1.Text; }
                if (textBox8.Text == "") { throw new Exception("Проверьте ввода Баланса"); }
                else { std.Balans = Convert.ToInt32(textBox8.Text); }
               
                std.Data_open = dateTimePicker2.Text;
                if (checkBox1.Checked==false) { std.Opevesh = "без подключение смс оповещения"; }
                else
                {
                    std.Opevesh = checkBox1.Text;
                }
                if (checkBox2.Checked==false) { std.Opevesh2 = "без подключение интернет-банкинга"; }
                else
                {
                    std.Opevesh2 = checkBox2.Text;
                }


                //std.Kurs = trackBar1.Value;
                //std.Average_mark = Convert.ToInt32(numericUpDown1.Value);

                std_list.Add(std);
                MessageBox.Show("Обьект добавлен в список");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message,"Предупреждение!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (std_list.Count != 0)
                {
                    for (var p = 0; p < std_list.Count; p++)
                    {
                       richTextBox1.Text = richTextBox1.Text  +"---------------------------------------"+ "Общая информация о владельце: " + "\n" + "  Фамилия: " + std_list[p].Vladelec.Family_name + "\n" + "  Имя: " + std_list[p].Vladelec.Name + "\n" + "  Отчество: " + std_list[p].Vladelec.Otcest + "\n" + "  Пол: " + std_list[p].Vladelec.Sex + "\n" + "  Дата рождения: " + std_list[p].Vladelec.Date_of_birth + "\n" + "  Паспорт№: " + std_list[p].Vladelec.Pasportno + "\n" + "  Персональный №: " + std_list[p].Vladelec.Personalno + "\n" + "  Место рождения: " + std_list[p].Vladelec.Place_of_birth + "\n" + "Счет:" + "\n" + "  номер счета: " + std_list[p].Nomer + "\n" + "  Тип вклада: " + std_list[p].Tip_vklada + "\n" + "  Баланс: " + std_list[p].Balans + "$\n" + "  Дата открытия: " + std_list[p].Data_open + "\n" + std_list[p].Opevesh + "\n" + std_list[p].Opevesh2+"\n\n";
                    }
                }
                else { throw new Exception("Список пуст"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (std_list.Count!=0)
                {
                    DataContractJsonSerializer jsonFormatter2 = new DataContractJsonSerializer(typeof(List<Scet>));
                    using (FileStream fs = new FileStream("D:\\фит\\ООП\\2 семестр лабы\\5 lab\\dowr.json", FileMode.OpenOrCreate))
                    {
                        if (fs.Length != 0)
                        {
                            std_list3=(List<Scet>)jsonFormatter2.ReadObject(fs);
                        }
                    }
                    // создаем объект Json
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Scet>));
                    // получаем поток, куда будем записывать сериализованный объект
                    
                    for (int i = 0; i < std_list3.Count; i++)
                    {
                        std_list.Add(std_list3[i]);
                    }
                    using (FileStream fs = new FileStream("D:\\фит\\ООП\\2 семестр лабы\\5 lab\\dowr.json", FileMode.Create))
                    {
                        jsonFormatter.WriteObject(fs, std_list);

                        MessageBox.Show("Объект сериализован(JSON)");
                    }
                    std_list.Clear();
                }
                else { throw new Exception("Список пуст"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
        try
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Scet>));

            using (FileStream fs = new FileStream("D:\\фит\\ООП\\2 семестр лабы\\5 lab\\dowr.json", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    std_list2 = (List<Scet>)jsonFormatter.ReadObject(fs);
                    for (var p = 0; p < std_list2.Count; p++)
                    {
                        richTextBox1.Text = richTextBox1.Text + "-----------------------------------------------------------------\n" + "Общая информация о владельце: " + "\n" + "  Фамилия: " + std_list2[p].Vladelec.Family_name + "\n" + "  Имя: " + std_list2[p].Vladelec.Name + "\n" + "  Отчество: " + std_list2[p].Vladelec.Otcest + "\n" + "  Пол: " + std_list2[p].Vladelec.Sex + "\n" + "  Дата рождения: " + std_list2[p].Vladelec.Date_of_birth + "\n" + "  Паспорт№: " + std_list2[p].Vladelec.Pasportno + "\n" + "  Персональный №: " + std_list2[p].Vladelec.Personalno + "\n" + "  Место рождения: " + std_list2[p].Vladelec.Place_of_birth + "\n" + "Счет:" + "\n" + "  номер счета: " + std_list2[p].Nomer + "\n" + "  Тип вклада: " + std_list2[p].Tip_vklada + "\n" + "  Баланс: " + std_list2[p].Balans + "$\n" + "  Дата открытия: " + std_list2[p].Data_open + "\n" + std_list2[p].Opevesh + "\n" + std_list2[p].Opevesh2 + "\n\n";
                    }
                    MessageBox.Show("Объект десериализован(JSON)");
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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите очистить файл JSON?", "Предупреждение!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (System.IO.File.Exists("D:\\фит\\ООП\\2 семестр лабы\\5 lab\\dowr.json"))
                {
                    File.WriteAllText("D:\\фит\\ООП\\2 семестр лабы\\5 lab\\dowr.json", "");
                    MessageBox.Show("JSON файл очислен!");
                }
                else { MessageBox.Show("Файл отсутствует!"); }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: " + "Атаев Доврангельды Джемшидович");

        }
    }
}
