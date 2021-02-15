using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лаб_5
{
    public partial class Form2 : Form
    {
        private Form1 m_parent;


        public Form2(Form1 frm1)
        {
            InitializeComponent();
            m_parent = frm1;
        }
       
       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string name =  textBox1.Text;


            // возвразщает кл

            if (radioButton1.Checked == true)
            {
                richTextBox1.Clear();
                m_parent.searchStdList.Clear();
                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < m_parent.StdListforsort.Count; i++)
                {
                    if (m_parent.StdListforsort[i].Vladelec.Family_name != search_arg)
                    {
                        continue;
                    }
                    else
                    {
                        m_parent.searchStdList.Add(m_parent.StdListforsort[i]);
                        c++;
                    }
                }

                if (c == 0) { richTextBox1.Text = "Поиск не дал результатов."; }
                else
                {
                    richTextBox1.Text = "";

                    for (var p = 0; p < m_parent.searchStdList.Count; p++)
                    {
                        richTextBox1.Text = richTextBox1.Text + "-----------------------------------------------------------------\n" + "Общая информация о владельце: " + "\n" + "  Фамилия: " + m_parent.searchStdList[p].Vladelec.Family_name + "\n" + "  Имя: " + m_parent.searchStdList[p].Vladelec.Name + "\n" + "  Отчество: " + m_parent.searchStdList[p].Vladelec.Otcest + "\n" + "  Пол: " + m_parent.searchStdList[p].Vladelec.Sex + "\n" + "  Дата рождения: " + m_parent.searchStdList[p].Vladelec.Date_of_birth + "\n" + "  Паспорт№: " + m_parent.searchStdList[p].Vladelec.Pasportno + "\n" + "  Персональный №: " + m_parent.searchStdList[p].Vladelec.Personalno + "\n" + "  Место рождения: " + m_parent.searchStdList[p].Vladelec.Place_of_birth + "\n" + "Счет:" + "\n" + "  номер счета: " + m_parent.searchStdList[p].Nomer + "\n" + "  Тип вклада: " + m_parent.searchStdList[p].Tip_vklada + "\n" + "  Баланс: " + m_parent.searchStdList[p].Balans + "$\n" + "  Дата открытия: " + m_parent.searchStdList[p].Data_open + "\n" + m_parent.searchStdList[p].Opevesh + "\n" + m_parent.searchStdList[p].Opevesh2 + "\n\n";
                    }
                }
            }
            if (radioButton2.Checked == true)
            {
                richTextBox1.Clear();
                m_parent.searchStdList.Clear();
                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < m_parent.StdListforsort.Count; i++)
                {
                    if (m_parent.StdListforsort[i].nomer != Convert.ToInt32( search_arg))
                    {
                        continue;
                    }
                    else
                    {
                        m_parent.searchStdList.Add(m_parent.StdListforsort[i]);
                        c++;
                    }
                }

                if (c == 0) { richTextBox1.Text = "Поиск не дал результатов."; }
                else
                {
                    richTextBox1.Text = "";

                    for (var p = 0; p < m_parent.searchStdList.Count; p++)
                    {
                        richTextBox1.Text = richTextBox1.Text + "-----------------------------------------------------------------\n" + "Общая информация о владельце: " + "\n" + "  Фамилия: " + m_parent.searchStdList[p].Vladelec.Family_name + "\n" + "  Имя: " + m_parent.searchStdList[p].Vladelec.Name + "\n" + "  Отчество: " + m_parent.searchStdList[p].Vladelec.Otcest + "\n" + "  Пол: " + m_parent.searchStdList[p].Vladelec.Sex + "\n" + "  Дата рождения: " + m_parent.searchStdList[p].Vladelec.Date_of_birth + "\n" + "  Паспорт№: " + m_parent.searchStdList[p].Vladelec.Pasportno + "\n" + "  Персональный №: " + m_parent.searchStdList[p].Vladelec.Personalno + "\n" + "  Место рождения: " + m_parent.searchStdList[p].Vladelec.Place_of_birth + "\n" + "Счет:" + "\n" + "  номер счета: " + m_parent.searchStdList[p].Nomer + "\n" + "  Тип вклада: " + m_parent.searchStdList[p].Tip_vklada + "\n" + "  Баланс: " + m_parent.searchStdList[p].Balans + "$\n" + "  Дата открытия: " + m_parent.searchStdList[p].Data_open + "\n" + m_parent.searchStdList[p].Opevesh + "\n" + m_parent.searchStdList[p].Opevesh2 + "\n\n";
                    }
                }
            }
            if (radioButton4.Checked == true)
            {
                richTextBox1.Clear();
                m_parent.searchStdList.Clear();
                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < m_parent.StdListforsort.Count; i++)
                {
                    if (m_parent.StdListforsort[i].tip_vklada != search_arg)
                    {
                        continue;
                    }
                    else
                    {
                        m_parent.searchStdList.Add(m_parent.StdListforsort[i]);
                        c++;
                    }
                }

                if (c == 0) { richTextBox1.Text = "Поиск не дал результатов."; }
                else
                {
                    richTextBox1.Text = "";

                    for (var p = 0; p < m_parent.searchStdList.Count; p++)
                    {
                        richTextBox1.Text = richTextBox1.Text + "-----------------------------------------------------------------\n" + "Общая информация о владельце: " + "\n" + "  Фамилия: " + m_parent.searchStdList[p].Vladelec.Family_name + "\n" + "  Имя: " + m_parent.searchStdList[p].Vladelec.Name + "\n" + "  Отчество: " + m_parent.searchStdList[p].Vladelec.Otcest + "\n" + "  Пол: " + m_parent.searchStdList[p].Vladelec.Sex + "\n" + "  Дата рождения: " + m_parent.searchStdList[p].Vladelec.Date_of_birth + "\n" + "  Паспорт№: " + m_parent.searchStdList[p].Vladelec.Pasportno + "\n" + "  Персональный №: " + m_parent.searchStdList[p].Vladelec.Personalno + "\n" + "  Место рождения: " + m_parent.searchStdList[p].Vladelec.Place_of_birth + "\n" + "Счет:" + "\n" + "  номер счета: " + m_parent.searchStdList[p].Nomer + "\n" + "  Тип вклада: " + m_parent.searchStdList[p].Tip_vklada + "\n" + "  Баланс: " + m_parent.searchStdList[p].Balans + "$\n" + "  Дата открытия: " + m_parent.searchStdList[p].Data_open + "\n" + m_parent.searchStdList[p].Opevesh + "\n" + m_parent.searchStdList[p].Opevesh2 + "\n\n";
                    }
                }
            }
            if (radioButton3.Checked == true)
            {
                richTextBox1.Clear();
                m_parent.searchStdList.Clear();
                var search_arg = textBox1.Text;
                var c = 0;
                for (var i = 0; i < m_parent.StdListforsort.Count; i++)
                {
                    if (m_parent.StdListforsort[i].balans != Convert.ToInt32(search_arg))
                    {
                        continue;
                    }
                    else
                    {
                        m_parent.searchStdList.Add(m_parent.StdListforsort[i]);
                        c++;
                    }
                }

                if (c == 0) { richTextBox1.Text = "Поиск не дал результатов."; }
                else
                {
                    richTextBox1.Text = "";

                    for (var p = 0; p < m_parent.searchStdList.Count; p++)
                    {
                        richTextBox1.Text = richTextBox1.Text + "-----------------------------------------------------------------\n" + "Общая информация о владельце: " + "\n" + "  Фамилия: " + m_parent.searchStdList[p].Vladelec.Family_name + "\n" + "  Имя: " + m_parent.searchStdList[p].Vladelec.Name + "\n" + "  Отчество: " + m_parent.searchStdList[p].Vladelec.Otcest + "\n" + "  Пол: " + m_parent.searchStdList[p].Vladelec.Sex + "\n" + "  Дата рождения: " + m_parent.searchStdList[p].Vladelec.Date_of_birth + "\n" + "  Паспорт№: " + m_parent.searchStdList[p].Vladelec.Pasportno + "\n" + "  Персональный №: " + m_parent.searchStdList[p].Vladelec.Personalno + "\n" + "  Место рождения: " + m_parent.searchStdList[p].Vladelec.Place_of_birth + "\n" + "Счет:" + "\n" + "  номер счета: " + m_parent.searchStdList[p].Nomer + "\n" + "  Тип вклада: " + m_parent.searchStdList[p].Tip_vklada + "\n" + "  Баланс: " + m_parent.searchStdList[p].Balans + "$\n" + "  Дата открытия: " + m_parent.searchStdList[p].Data_open + "\n" + m_parent.searchStdList[p].Opevesh + "\n" + m_parent.searchStdList[p].Opevesh2 + "\n\n";
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите какой поиск!");
            }

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
         
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

     
    }
}
