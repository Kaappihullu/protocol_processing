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
        public static TreeNode CreateNetworkNode(SimulationNetwork network)
        {

            TreeNode treeNode = new TreeNode(network.NetworkTag);
            treeNode.Tag = network;

            foreach (NetworkNode node in network.NetworkNodes)
            {
                TreeNode treeNetworkNode = new TreeNode(node.Address);
                treeNetworkNode.Tag = node;
                treeNode.Nodes.Add(treeNetworkNode);
            }
            return treeNode;

        }

        private void rebuildNetworkView()
        {
            m_networkView.Nodes.Clear();
            foreach (SimulationNetwork network in SimulationNetwork.Networks)
            {
                m_networkView.Nodes.Add(CreateNetworkNode(network));
            }
        }


        private void m_addNetworkButton_Click(object sender, EventArgs e)
        {
            rebuildNetworkView();
            SimulationNetwork.RunAll();
            m_addNetworkButton.Enabled = false;
        }

        private void m_networkView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (m_networkView.SelectedNode.Tag.GetType() == typeof(NetworkNode))
            {
             //   new NetworkNodeForm((m_networkView.SelectedNode.Tag as NetworkNode)).Show();
                NetworkNodeForm form = new NetworkNodeForm((m_networkView.SelectedNode.Tag as NetworkNode));
                form.Show();
            }
        }

        private void m_intervalTimer_Tick(object sender, EventArgs e)
        {
            m_packetCounterLabel.Text = "Packet Counter: " + NetworkNode.PacketCounter;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void m_configButton_Click(object sender, EventArgs e)
        {
            ConfigForm.ShowForm();
        }
    }
}
