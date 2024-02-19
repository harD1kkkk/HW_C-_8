using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int score = 0;
        private int Health = 3;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer1.Interval = 10;
            timer2.Interval = 1000;
            timer3.Interval = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in pictureBoxes)
            {
                item.Location = new Point(item.Location.X + 1, item.Location.Y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            this.Controls.Remove(picture);
            pictureBoxes.Remove(picture);
            score++;
            label1.Text = "Score: " + score.ToString();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            PictureBox pictureBox1 = new PictureBox();
            Image image = Image.FromFile("C:\\Users\\student\\Pictures\\enemy.png");
            pictureBox1.Location = new Point(0, random.Next(50, Screen.PrimaryScreen.Bounds.Height - 100));
            pictureBox1.Size = new Size(image.Width, image.Height);
            pictureBox1.Image = image;
            pictureBox1.Click += pictureBox1_MouseClick;
            this.Controls.Add(pictureBox1);
            pictureBoxes.Add(pictureBox1);


        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            List<PictureBox> pictureToDelete = new List<PictureBox>();
            bool gameOver = false;

            foreach (var item in pictureBoxes)
            {
                if (Health <= 0)
                {
                    gameOver = true; 
                    break; 
                }
                if (item.Location.X >= Screen.PrimaryScreen.Bounds.Width)
                {
                    this.Controls.Remove(item);
                    pictureToDelete.Add(item);
                }
            }
            foreach(var item in pictureToDelete)
            {
                pictureBoxes.Remove(item);
                AddDecrement();
                
            }

            label2.Text = "Health: " + Health.ToString();

            if (gameOver)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                MessageBox.Show("GAME OVER", "Health == 0");
            }

        }

        private void AddDecrement()
        {
            Interlocked.Decrement(ref Health); 
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

