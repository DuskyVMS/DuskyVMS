using DuskyVMS.Protocols.RTP;
using System.Net.Sockets;

namespace DuskyVMS.Workers
{
    public class StreamPOC
    {
        public StreamPOC()
        {
            DuskyVMS.Logger.LogInformation("Starting stream...");
            var connection = new RtspConnection(new("rtsp://admin:iseeyou!1@ba-mv-cm1/media/video1"));
            connection.ConnectAsync().Wait();
            connection.DescribeAsync();
        }
    }
}