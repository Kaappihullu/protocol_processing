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
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            rebuildNetworkView();
        }

        public static void ShowForm()
        {
            
            new ConfigForm().Show();
        }

        private void rebuildNetworkView()
        {
            m_networksView.Nodes.Clear();
            foreach (SimulationNetwork network in SimulationNetwork.Networks)
            {
                m_networksView.Nodes.Add(MainForm.CreateNetworkNode(network));
            }
        }

        private void m_createNetworkButton_Click(object sender, EventArgs e)
        {
            AddNetworkForm.ShowForm();
            rebuildNetworkView();
        }

        private NetworkNode[] nonConnectedNodes(NetworkNode node)
        {
            List<NetworkNode> nodes = new List<NetworkNode>();
            foreach (SimulationNetwork network in SimulationNetwork.Networks)
            {
                foreach (NetworkNode networkNode in network.NetworkNodes)
                {
                    if (!node.IsConnected(networkNode))
                    {
                        nodes.Add(networkNode);
                    }
                }
            }
            return nodes.ToArray();
        }

        private void m_NetworksView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is NetworkNode)
            {
                m_availableRouters.Items.Clear();
                m_availableRouters.Items.AddRange(nonConnectedNodes((NetworkNode)e.Node.Tag));
            }
        }

        private void m_LinkButton_Click(object sender, EventArgs e)
        {
            if (m_networksView.SelectedNode.Tag is NetworkNode && m_availableRouters.SelectedIndex != -1) 
            {
                ((NetworkNode)m_networksView.SelectedNode.Tag).Link((NetworkNode)m_availableRouters.SelectedItem);

                
            }


        }
    }


}
