using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ProtocolProcessingGUI
{

    public class PInvoke
    {
        public const String DLL = "ProtocolProcessing.dll";
    }

    public class NetworkNode
    {

        private IntPtr m_ptr;

        [DllImport(PInvoke.DLL)]
        public static extern IntPtr network_create_node(IntPtr addr);

        public NetworkNode(String addr)
        {
            
        }

        public void Send(byte[] data, String dst)
        {  
        }

        public void Recv()
        {
        }

        public IntPtr Ptr
        {
            get
            {
                return m_ptr;
            }
        }

    }

    public class SimulationNetwork
    {

        private IntPtr m_ptr;

        [DllImport(PInvoke.DLL)]
        public static extern IntPtr network_create_simulation_network();

        [DllImport(PInvoke.DLL)]
        public static extern IntPtr network_add_simulation_network(IntPtr simulation_network, IntPtr network_node);


        public SimulationNetwork()
        {
            m_ptr = network_create_simulation_network();
        }

        public void AddNode(NetworkNode node)
        {
            network_add_simulation_network(m_ptr,node.Ptr);
        }

    }
}
