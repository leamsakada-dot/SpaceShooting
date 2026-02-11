using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace FighterJetCam
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        WindowsMediaPlayer bgMusic = new WindowsMediaPlayer();
        WindowsMediaPlayer welcome = new WindowsMediaPlayer();
        private void label1_BackColorChanged(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void loadgame(object sender, EventArgs e)
        {
            Form1 gamewindow = new Form1();
            gamewindow.Show();
            bgMusic.controls.stop();
            welcome.controls.stop();
            this.Hide();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;  
            pictureBox5.BackColor = Color.Transparent;

            bgMusic.URL = @"C:\Jetelement\startbg.mp3";
            bgMusic.settings.volume = 20;
            bgMusic.controls.play();
           
            welcome.URL = @"C:\Jetelement\Welcome.mp3";
            welcome.settings.setMode("loop", true);
            welcome.settings.volume = 30;
            welcome.controls.play();
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
