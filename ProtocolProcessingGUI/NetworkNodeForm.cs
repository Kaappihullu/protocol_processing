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
    public partial class NetworkNodeForm : Form
    {

        private NetworkNode m_networkNode;
        private int m_lastPacketCount = 0;

        public NetworkNodeForm(NetworkNode node)
        {
            m_networkNode = node;
            NodeRoute[] routes = node.NetworkRoutes;
            InitializeComponent();
            this.Text = node.Address;
            
        }

        private void m_commandButton_Click(object sender, EventArgs e)
        {
            char[] splitChar = {' '};
            String[] command = m_commandBox.Text.Split(splitChar,3);
             //yuck
            if (command[0] == "send")
            {
                if (command[1].Contains(":"))
                {
                    m_networkNode.SendHost(Encoding.Default.GetBytes(command[2]),command[1]);
                }
                else
                {
                    m_networkNode.SendRaw(Encoding.Default.GetBytes(command[2]), command[1]);
                }
            }

        }

        private void m_updateInterval_Tick(object sender, EventArgs e)
        {
            //m_logBox.Clear();

            if (m_lastPacketCount == m_networkNode.ReceivedPackets.Count)
            {
                return;
            }

            m_lastPacketCount = m_networkNode.ReceivedPackets.Count;

            m_logBox.Text = "Received packet count: "+m_networkNode.ReceivedPackets.Count+"\r\n";

            foreach(NodeRoute route in m_networkNode.NetworkRoutes)
            {
                m_logBox.Text += route.EntryIp + " via " + route.RouteIp + " hops " + route.Hops + "\r\n";
            }

            foreach (SocketPacket packet in m_networkNode.ReceivedPackets)
            {
                if (!packet.IsTCP)
                {

                    if (packet.DestinationAddress != m_networkNode.Address)
                    {
                        m_logBox.Text += "Routing packet to" + packet.DestinationAddress + "\r\n" ;
                    }
                    else
                    {
                        m_logBox.Text += packet.ToString() + "\r\n";
                    }
                }
            }
        }
    }
}
