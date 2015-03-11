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
            network.AddNode(new NetworkNode("172.0.0.2"));

            TreeNode treeNode = m_networkView.Nodes.Add("network1");
            treeNode.Tag = network;


            foreach (NetworkNode node in network.NetworkNodes)
            {
                TreeNode networkTreeNode = treeNode.Nodes.Add(node.Address);
                networkTreeNode.Tag = node;
            }
            m_addNetworkButton.Enabled = false;
        }

        private void m_networkView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (m_networkView.SelectedNode.Tag.GetType() == typeof(NetworkNode))
            {
                new NetworkNodeForm((m_networkView.SelectedNode.Tag as NetworkNode)).Show();
            }
        }
    }
}
