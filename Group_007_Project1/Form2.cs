using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_007_Project1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int num1 = rnd.Next(1,51);
            int num2 = rnd.Next(1,51);
            int sign = rnd.Next(1,3);
            int sum = 0;
            if (button.Text == "Start")
            {
                textBox1.Enabled = true;
                label1.Text = num1.ToString();
                label3.Text = num2.ToString();
                label2.Text = Sign(sign);
                label5.Text = "100";

                button.Text = "Stop";
                timer1.Enabled = true;

                listBox1.Items.Clear();
                label7.Text = "0";
            }else
            {
                button.Text = "Start";
                textBox1.Enabled=false;

                foreach(string number in listBox1.Items)
                {

                    sum += Convert.ToInt32(number);
                }
                label5.Text = "0";
                label7.Text = sum.ToString();

                timer1.Enabled=false;
            }
        }

        static string Sign (int sign)
        {
            string s = sign.ToString();
            string sgn;

            if(s == "1")
            {
                sgn = "+";
            }else
            {
                sgn = "-"; 
            }

                return sgn;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int number = Convert.ToInt32(label5.Text);

            number--;

            label5.Text = number.ToString();    

            if (label5.Text == "0")
            {
                label5.Text = "100";

               label1.Text = rnd.Next(1, 51).ToString();
               label3.Text = rnd.Next(1, 51).ToString();
               label2.Text = Sign(rnd.Next(0,3));

                listBox1.Items.Add("0");

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Random rnd = new Random();  
            string number1 = label1.Text;
            string number2 = label3.Text;
            string sign = label2.Text;

            if (textBox1.Text == calculation(number1,number2,sign))
            {
                listBox1.Items.Add(label5.Text);
                textBox1.Text = "";

                label5.Text = "100";

                label1.Text = (rnd.Next(1, 51)).ToString();
                label3.Text = (rnd.Next(1, 51)).ToString();
                label2.Text = (Sign(rnd.Next(0, 3)));
                sign = label2.Text;
                
                
            }
        }

        static string calculation (string a, string b, string text)
        {
            int num = Convert.ToInt32(a);
            int num2 = Convert.ToInt32(b);
            int result = 0;

            if (text == "+")
            {
                result = num + num2;

                
            }else
            {
                result = num - num2;
            }

            return result.ToString();
        }
        
    }
}
