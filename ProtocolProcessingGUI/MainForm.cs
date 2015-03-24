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
            SimulationNetwork network1 = new SimulationNetwork();
            NetworkNode n1 = new NetworkNode("172.0.0.1");
            network1.AddNode(n1);
            network1.AddNode(new NetworkNode("172.0.0.2"));

            TreeNode treeNode1 = m_networkView.Nodes.Add("network1");

            SimulationNetwork network2 = new SimulationNetwork();
            NetworkNode n2 = new NetworkNode("172.0.1.1");
            network2.AddNode(n2);
            network2.AddNode(new NetworkNode("172.0.1.2"));

            TreeNode treeNode2 = m_networkView.Nodes.Add("network2");

            n1.Link(n2);
            n2.Link(n1);

            treeNode1.Tag = network1;
            treeNode2.Tag = network2;

            foreach (NetworkNode node in network1.NetworkNodes)
            {
                TreeNode networkTreeNode = treeNode1.Nodes.Add(node.Address);
                networkTreeNode.Tag = node;
            }
            foreach (NetworkNode node in network2.NetworkNodes)
            {
                TreeNode networkTreeNode = treeNode2.Nodes.Add(node.Address);
                networkTreeNode.Tag = node;
            }
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
            foreach (SimulationNetwork network in SimulationNetwork.Networks)
            {
                network.DoLoop();
            }
        }
    }
}
