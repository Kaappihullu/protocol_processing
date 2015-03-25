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

        private TreeNode createNetworkNode(String prefix, int count)
        {

            SimulationNetwork network = new SimulationNetwork();

            for (int i = 0; i < count; i++)
            {
                network.AddNode(new NetworkNode(prefix+"."+(i+1)));
            }


            TreeNode treeNode = new TreeNode("network");
            treeNode.Tag = network;

            foreach (NetworkNode node in network.NetworkNodes)
            {
                TreeNode treeNetworkNode = new TreeNode(node.Address);
                treeNetworkNode.Tag = node;
                treeNode.Nodes.Add(treeNetworkNode);
            }
            return treeNode;
        }

        private void m_addNetworkButton_Click(object sender, EventArgs e)
        {
            /*SimulationNetwork network1 = new SimulationNetwork();
            NetworkNode n1 = new NetworkNode("172.0.0.1");
            network1.AddNode(n1);
            network1.AddNode(new NetworkNode("172.0.0.2"));

            TreeNode treeNode1 = m_networkView.Nodes.Add("network1");

            SimulationNetwork network2 = new SimulationNetwork();
            NetworkNode n2 = new NetworkNode("172.0.1.1");
            network2.AddNode(n2);
            network2.AddNode(new NetworkNode("172.0.1.2"));

            TreeNode treeNode2 = m_networkView.Nodes.Add("network2");
            */

            TreeNode node1 = createNetworkNode("172.0.0", 3);
            TreeNode node2 = createNetworkNode("172.0.1", 3);
            TreeNode node3 = createNetworkNode("172.0.2", 3);
           // TreeNode node4 = createNetworkNode("172.0.3", 3);

            ((SimulationNetwork)node1.Tag).NetworkNodes[0].Link(((SimulationNetwork)node2.Tag).NetworkNodes[0]);
            ((SimulationNetwork)node2.Tag).NetworkNodes[0].Link(((SimulationNetwork)node3.Tag).NetworkNodes[0]);
            //((SimulationNetwork)node3.Tag).NetworkNodes[0].Link(((SimulationNetwork)node4.Tag).NetworkNodes[0]);

            m_networkView.Nodes.Add(node1);
            m_networkView.Nodes.Add(node2);
            m_networkView.Nodes.Add(node3);
            //m_networkView.Nodes.Add(node4);
            //n1.Link(n2);

            ((SimulationNetwork)node1.Tag).Run();
            ((SimulationNetwork)node2.Tag).Run();
            ((SimulationNetwork)node3.Tag).Run();
            //((SimulationNetwork)node1.Tag).Run();

            /*foreach (NetworkNode node in network1.NetworkNodes)
            {
                TreeNode networkTreeNode = treeNode1.Nodes.Add(node.Address);
                networkTreeNode.Tag = node;
            3
            foreach (NetworkNode node in network2.NetworkNodes)
            {
                TreeNode networkTreeNode = treeNode2.Nodes.Add(node.Address);
                networkTreeNode.Tag = node;
            }*/
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
               // network.DoLoop();
            }
        }
    }
}
