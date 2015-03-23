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

    [StructLayout(LayoutKind.Sequential)]
    public class NodeRoute
    {
        public Int32 EntryAddr;
        public Int32 RouteAddr;

        public Int32 hops;

    }

    [StructLayout(LayoutKind.Sequential)]
    public class SocketPacket
    {
	    public Int32 Marker;

	    public Int32 Addr;
	    public Int16 Mtu;

	    public Int16 PacketLen;

	    public IntPtr PaketPayload;


        public byte[] Payload
        {
            get
            {
                byte[] payloadBytes = new byte[PacketLen-(IsTCP ?  24 : 12)];

                for (int i = 0; i < payloadBytes.Length; i++)
                {
                    payloadBytes[i] = Marshal.ReadByte(PaketPayload,i + (IsTCP ? 12 : 0));
                }
                return payloadBytes;
            }
        }

        public bool IsTCP
        {
            get
            {
                return (is_tcp_segment(this) == 0);
            }
        }

        public override string ToString()
        {
            return IsTCP ? "TCP: " + Encoding.Default.GetString(Payload) : Encoding.Default.GetString(Payload);
        }

        [DllImport(PInvoke.DLL,CallingConvention=CallingConvention.Cdecl)]
        private extern static Int32 is_tcp_segment(SocketPacket packet);

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
        


        private static Dictionary<String,List<SocketPacket>> m_packets = new Dictionary<String,List<SocketPacket>>();

        public delegate void PacketSniffer(IntPtr network_node, SocketPacket packet);
        //to force the GC not to release this object.
        private static PacketSniffer m_sniffer = onPacketSniffer;


        public NetworkNode(String addr)
        {
            m_ptr = network_create_node(SimSocket.ConvertIPAddress(addr));
            installPacketSniffer(m_sniffer);
        }

        public NetworkNode(IntPtr ptr)
        {
            m_ptr = ptr;
        }


        public void SendRaw(byte[] data, String dst)
        {
            simulation_send_raw_socket(m_ptr,data,data.Length,SimSocket.ConvertIPAddress(dst));
        }

        public void SendHost(byte[] data, String dst)
        {
            char[] splitChar = {':'};
            String[] dstAddr = dst.Split(splitChar);

            simulation_send_host(m_ptr,SimSocket.ConvertIPAddress(dstAddr[0]),data,data.Length,Convert.ToInt16(dstAddr[1]));

        }

        public SocketPacket ReceiveRaw()
        {
            IntPtr packet = simulation_receive_raw_socket(Ptr);
            if (packet == IntPtr.Zero)
            {
                return null;
            }

            SocketPacket socketPacket = (SocketPacket)Marshal.PtrToStructure(packet,typeof(SocketPacket));

            ReceivedPackets.Add(socketPacket);

            return socketPacket;
        }

        private static void onPacketSniffer(IntPtr network_node, SocketPacket packet)
        {
            NetworkNode node = new NetworkNode(network_node);
            node.ReceivedPackets.Add(packet);
        }

        private void installPacketSniffer(PacketSniffer sniffer)
        {
            network_node_install_packet_sniffer(Ptr,Marshal.GetFunctionPointerForDelegate(sniffer));
        }

        public List<SocketPacket> ReceivedPackets
        {
            get
            {

                if (!m_packets.ContainsKey(Address))
                {
                    m_packets.Add(Address, new List<SocketPacket>());
                }

                return m_packets[Address];
            }
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

        [DllImport(PInvoke.DLL,CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 simulation_send_host(IntPtr sender, byte[] addr, byte[] data, Int32 size,Int16 port);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr simulation_receive_raw_socket(IntPtr dst);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void network_node_install_packet_sniffer(IntPtr network_node,IntPtr sniffer);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void network_link_network(IntPtr node1, IntPtr node2);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int network_get_route_count(IntPtr node);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern NodeRoute network_get_route_by_index(IntPtr node, int index);

    }

    public class SimulationNetwork
    {

        private static List<SimulationNetwork> m_networks = new List<SimulationNetwork>();

        private IntPtr m_ptr;

        public static SimulationNetwork[] Networks
        {
            get
            {
                return m_networks.ToArray();
            }
        }

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


        public void AddNode(NetworkNode node)
        {
            network_add_simulation_network(m_ptr, node.Ptr);
        }

        public void DoLoop()
        {
            network_do_loop(m_ptr);
        }

        public SimulationNetwork()
        {
            m_ptr = network_create_simulation_network();
            m_networks.Add(this);
        }

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr network_create_simulation_network();

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr network_add_simulation_network(IntPtr simulation_network, IntPtr network_node);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int network_get_node_count(IntPtr simulation_network);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr network_get_node_by_index(IntPtr simulation_network, int index);

        [DllImport(PInvoke.DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void network_do_loop(IntPtr simulation_network);
    }
}
