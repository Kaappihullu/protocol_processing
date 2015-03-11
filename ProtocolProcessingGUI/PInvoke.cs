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

        public static byte[] ConvertIPAddress(String addr)
        {
            String[] split = addr.Split('.');
            byte[] byteAddr = new byte[4];

            byteAddr[0] = Convert.ToByte(split[0]);
            byteAddr[1] = Convert.ToByte(split[1]);
            byteAddr[2] = Convert.ToByte(split[2]);
            byteAddr[3] = Convert.ToByte(split[3]);

            return byteAddr;
        }

        public static String ConvertIPAddress(IntPtr addr)
        {
           
            return ConvertIPAddress(BitConverter.GetBytes(Marshal.ReadInt32(addr)));
        }

        public static String ConvertIPAddress(byte[] addr)
        {
            if (addr.Length != 4)
            {
                return "127.0.0.1";
            }

            return addr[0] + "." + addr[1] + "." + addr[2] + "." + addr[3];

        }

    }

    public class NetworkNode
    {

        private IntPtr m_ptr;

        public NetworkNode(String addr)
        {
            m_ptr = network_create_node(SimSocket.ConvertIPAddress(addr));
        }

        public NetworkNode(IntPtr ptr)
        {
            m_ptr = ptr;
        }

        public void Send(byte[] data, String dst)
        {
            simulation_send_raw_socket(m_ptr,data,data.Length,SimSocket.ConvertIPAddress(dst));
        }

        public void Recv()
        {
        }

        public String Address
        {
            get
            {
                return SimSocket.ConvertIPAddress(network_node_get_address(m_ptr));
            }
        }

        public IntPtr Ptr
        {
            get
            {
                return m_ptr;
            }
        }

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr network_node_get_address(IntPtr node);

        [DllImport(PInvoke.DLL,CallingConvention= CallingConvention.Cdecl)]
        public static extern IntPtr network_create_node(byte[] addr);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 simulation_send_raw_socket(IntPtr src, byte[] data, Int32 size, byte[] dst);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr simulation_receive_raw_socket(IntPtr dst);

    }

    public class SimulationNetwork
    {

        private IntPtr m_ptr;

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr network_create_simulation_network();

        [DllImport(PInvoke.DLL,CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr network_add_simulation_network(IntPtr simulation_network, IntPtr network_node);

        [DllImport(PInvoke.DLL,CallingConvention=CallingConvention.Cdecl)]
        public static extern int network_get_node_count(IntPtr simulation_network);

        [DllImport(PInvoke.DLL,CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr network_get_node_by_index(IntPtr simulation_network, int index);

        public NetworkNode[] NetworkNodes
        {
            get
            {
                NetworkNode[] nodes = new NetworkNode[network_get_node_count(m_ptr)];

                for (int i = 0; i < nodes.Length; i++ )
                {
                    nodes[i] = new NetworkNode(network_get_node_by_index(m_ptr,i));
                }

                return nodes;
            }
        }

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
