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
    public partial class AddNetworkForm : Form
    {
        public AddNetworkForm()
        {
            InitializeComponent();
        }

        private void m_okButton_Click(object sender, EventArgs e)
        {

            if (!m_ipRangeBox.Text.Contains("/"))
            {
                MessageBox.Show("Missing /");
                return;
            }
            
            SimulationNetwork network = new SimulationNetwork();
            if (m_nameTagBox.Text != "")
            {
                network.NetworkTag = m_nameTagBox.Text;
            }

            String[] split = m_ipRangeBox.Text.Split('/');
 
            int nodeCount =  Convert.ToInt32(split[1]);

            String[] address = split[0].Split('.');

            for (int i = 0; i < nodeCount; i++)
            {
                network.AddNode(new NetworkNode(address[0] + "." + address[1] + "." + address[2] + "." + (Convert.ToInt32(address[3]) + i)));
            }

            Close();
        }

        private void m_cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static void ShowForm()
        {
            new AddNetworkForm().ShowDialog();
        }
    }
}
