using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using WMPLib;

namespace Touhou__1_The_Approved_Assignment
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
            player.URL = "menu.mp3";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.FormClosed += (s, args) => this.Close();
            f2.Show();
            f2.Focus();
            player.controls.stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.FormClosed += (s, args) => this.Close();
            f3.Show();
            f3.Focus();
            player.controls.stop();
        }
    }
}
