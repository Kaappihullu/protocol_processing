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

        public NetworkNodeForm(NetworkNode node)
        {
            m_networkNode = node;

            InitializeComponent();
        }

        private void m_commandButton_Click(object sender, EventArgs e)
        {
            char[] splitChar = {' '};
            String[] command = m_commandBox.Text.Split(splitChar,3);
             //yuck
            if (command[0] == "send")
            {
                m_networkNode.Send(Encoding.Default.GetBytes(command[2]),command[1]);
            }

        }
    }
}
