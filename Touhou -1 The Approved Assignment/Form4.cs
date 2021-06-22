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
    public partial class Form4 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public Form4()
        {
            InitializeComponent();
            player.URL = "menu.mp3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.FormClosed += (s, args) => this.Close();
            f1.Show();
            f1.Focus();
            player.controls.stop();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
