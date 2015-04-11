using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProtocolProcessingGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SenderNetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SenderNetCombo.Items.Add("test1");
            SenderNetCombo.Items.Add("test2");
            SenderNetCombo.Items.Add("test3");
            SenderNetCombo.SelectedItem = "test3";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
