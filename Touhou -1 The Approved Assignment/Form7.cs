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
    public partial class Form7 : Form
    {     
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public Form7()
        {
            InitializeComponent();
            player.URL = "form7.mp3";
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {
           player.controls.play();
           linkLabel1.Text = "@Yagato02";
           linkLabel1.Links.Add(0, 0, "https://twitter.com/Yagato02");
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

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
