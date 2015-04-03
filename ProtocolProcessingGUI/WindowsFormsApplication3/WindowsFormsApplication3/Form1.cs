using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
       // private int leftLocation = 127, rightLocation = 200;
        //private int difference = 5;


        public Form1()
        {

            InitializeComponent();
        }



        private void NetworkButton_Click(object sender, EventArgs e)
        {
            NetworkLabel.Text = "2 Networks Added";
            AS01.Visible = true;
            AS02.Visible = true;
        }

        private void NetworkLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void NodeButton_Click(object sender, EventArgs e)
        {
            NodeLabel.Text = "Routers Added";
            AS01Box.Visible = true;
            AS02Box.Visible = true;
            //AS02Box.Image = Properties.Resources.router;
            AS02Box.ImageLocation = "http://www.michaelhanley.org/photos/uncategorized/2008/06/22/ciscorouter.png";
            AS01Box.ImageLocation = "http://www.michaelhanley.org/photos/uncategorized/2008/06/22/ciscorouter.png";
            //AS02Box.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void AS02Box_Click(object sender, EventArgs e)
        {

        }

               
        private void TCPButton_Click(object sender, EventArgs e)
        {
            //Networkcircle.Visible = true;
            TCPLabel.Text = "TCP Network Active";
            AS02Box.Image = Properties.Resources.router;
            AS01Box.Image = Properties.Resources.router;
            
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }


    }
}
