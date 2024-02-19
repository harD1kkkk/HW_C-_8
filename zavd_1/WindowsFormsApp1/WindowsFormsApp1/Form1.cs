using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, DateTime> dates = new Dictionary<string, DateTime>();
        bool isPressed = false;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text;
            listBox1.Items.Add(str);
            isPressed = true;
            var time = DateTime.Parse($"{textBox1.Text}:{textBox2.Text}:{textBox3.Text}");

            dates.Add(textBox4.Text, time);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isPressed == true)
            {
                var timeNow = DateTime.Parse(DateTime.Now.ToString());
                foreach (var item in dates.Keys)
                {
                    if (dates[item].Equals(timeNow))
                    {
                        MessageBox.Show(item);
                    }
                }

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
