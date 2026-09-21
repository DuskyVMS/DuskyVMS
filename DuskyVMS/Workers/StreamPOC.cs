using DuskyVMS.Protocols.RTP;
using System.Net.Sockets;

namespace DuskyVMS.Workers
{
    public class StreamPOC
    {
        public StreamPOC()
        {
            DuskyVMS.Logger.LogInformation("Starting stream...");
            new RtpStream(5005, ProtocolType.Udp);
        }
    }
}