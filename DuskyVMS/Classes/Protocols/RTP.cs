using System.Net;
using System.Net.Sockets;
using DuskyVMS.Definitions;

namespace DuskyVMS.Protocols.RTP
{
    public class RtpStream : IDisposable
    {
        public StreamTypes Type;
        public string MimeType;
        public Stream Stream;
        public byte[] Buffer;
        public uint ID;
        public Socket Socket;

        public RtpStream(int ListenPort, uint BufferSize = 10240)
        {
            Buffer = new byte[BufferSize];
            IPEndPoint endpoint = new(IPAddress.Any, ListenPort);
            Socket = new(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
            Socket.DualMode = true;
            Socket.ExclusiveAddressUse = true;
            Socket.Bind(endpoint);
        }

        public RtpStream(uint BufferSize = 10240)
        {
            Buffer = new byte[BufferSize];
            //Do stuff here with the RTSP connection
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}