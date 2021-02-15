using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Calculator!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                return;
            double res =  Calculator.Sin(Convert.ToDouble( textBox1.Text));
            textBox1.Text = Convert.ToString(res);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                return;
            double res = Calculator.Cos(Convert.ToDouble(textBox1.Text));
            textBox1.Text = Convert.ToString(res);
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                return;
            double res = Calculator.Tang(Convert.ToDouble(textBox1.Text));
            textBox1.Text = Convert.ToString(res);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                return;
            double res = Calculator.Sqrt(Convert.ToDouble(textBox1.Text));
            textBox1.Text = Convert.ToString(res);
        }

        double res1;
        double res2;
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                return;
            res1 = Convert.ToDouble(textBox1.Text);
             textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                return;
            res2 = Convert.ToDouble(textBox1.Text);
            double ress = Calculator.Pow(res1,res2);
            textBox1.Text = Convert.ToString(ress);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Convert.ToString(2);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text+Convert.ToString(1);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Convert.ToString(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Convert.ToString(4);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Convert.ToString(5);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Convert.ToString(6);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Convert.ToString(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Convert.ToString(8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Convert.ToString(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Convert.ToString(0);
        }

        List<string> result = new List<string>();
        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("Saved !"))
                return;
            result.Add(textBox1.Text);
            textBox1.Text = "Saved !";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            foreach (var item in result)
            {
                textBox1.Text = item;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}
