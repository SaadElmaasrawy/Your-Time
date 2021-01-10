using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Your_Time
{
    public partial class Form1 : Form
    {

        private SoundPlayer sound;

        int h;
        int min;
        int sec;



        public void ex(int x, int y)
        {
            textBox2.Text = x.ToString();
            textBox3.Text = y.ToString();
            timer1.Enabled = true;
        }

        public void checking()
        {
            if (Int32.Parse(textBox3.Text) < 0 || Int32.Parse(textBox3.Text) > 60)
            {
                MessageBox.Show("sec cant be less than 0 or more that 60.");
            }
            else if (Int32.Parse(textBox2.Text) < 0 || Int32.Parse(textBox2.Text) > 60)
            {
                MessageBox.Show("min cant be less than 0 or more that 60.");
            }
            else if (Int32.Parse(textBox1.Text) < 0 || Int32.Parse(textBox1.Text) > 24)
            {
                MessageBox.Show("h cant be less than 0 or more that 24.");
            }
            else timer1.Enabled = true;
        }

        public Form1()
        {
            InitializeComponent();
            sound = new SoundPlayer("sound1.wav");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checking();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            h = Int32.Parse(textBox1.Text);
            min = Int32.Parse(textBox2.Text);
            sec = Int32.Parse(textBox3.Text);
            sec--;
            textBox3.Text = sec.ToString();
            int duration = sec + (min * 60) + (h * 60);
            if (Int32.Parse(textBox3.Text) < 0 || Int32.Parse(textBox2.Text) < 0 || Int32.Parse(textBox1.Text) < 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("if you want to set timer to 5 hours please fill boxes like h = 4 , min = 59 and sec = 60");
            }
            if (duration == 0)
            {
                sound.Play();
                timer1.Enabled = false;
                sec = 0;
            }
            if (sec == 0 & min > 0)
            {
                min--;
                textBox2.Text = min.ToString();
                sec = 60;
                textBox3.Text = sec.ToString();
                timer1.Enabled = true;
            }
            if (min == 0 & h > 0)
            {
                h--;
                textBox1.Text = h.ToString();
                min = 60;
                textBox2.Text = min.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ex(4, 60);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ex(24, 60);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ex(44, 60);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ex(59, 60);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            (new info()).Show();

        }

    }
}