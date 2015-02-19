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

    public class SimSocket
    {
        private IntPtr m_ptr;

        public SimSocket(IntPtr ptr)
        {
            m_ptr = ptr;
        }

        public static byte[] CreateIPAddress(String addr)
        {
            String[] split = addr.Split('.');
            byte[] byteAddr = new byte[4];

            byteAddr[0] = Convert.ToByte(split[0]);
            byteAddr[1] = Convert.ToByte(split[1]);
            byteAddr[2] = Convert.ToByte(split[2]);
            byteAddr[3] = Convert.ToByte(split[3]);

            return byteAddr;
        }

    }

    public class NetworkNode
    {

        private IntPtr m_ptr;

        public NetworkNode(String addr)
        {
            m_ptr = network_create_node(SimSocket.CreateIPAddress(addr));
        }

        public void Send(byte[] data, String dst)
        {
            simulation_send_raw_socket(m_ptr,data,data.Length,SimSocket.CreateIPAddress(dst));
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

        [DllImport(PInvoke.DLL,CallingConvention= CallingConvention.Cdecl)]
        public static extern IntPtr network_create_node(byte[] addr);

        [DllImport(PInvoke.DLL)]
        private static extern Int32 simulation_send_raw_socket(IntPtr src, byte[] data, Int32 size, byte[] dst);
        
        [DllImport(PInvoke.DLL)]
        private static extern IntPtr simulation_receive_raw_socket(IntPtr dst);

    }

    public class SimulationNetwork
    {

        private IntPtr m_ptr;

        [DllImport(PInvoke.DLL)]
        public static extern IntPtr network_create_simulation_network();

        [DllImport(PInvoke.DLL,CallingConvention=CallingConvention.Cdecl)]
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
