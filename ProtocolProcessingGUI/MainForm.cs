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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void m_addNetworkButton_Click(object sender, EventArgs e)
        {
            SimulationNetwork network = new SimulationNetwork();
            network.AddNode(new NetworkNode("172.0.0.1"));
        }
    }
}
