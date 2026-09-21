using System.Net;
using System.Net.Sockets;
using DuskyVMS.Definitions;

namespace DuskyVMS.Protocols.RTP
{
    public class RtspConnection : IDisposable
    {
        public Uri URI;
        public RtpStream[] RtpStreams = Array.Empty<RtpStream>();
        public TcpClient Client;
        public RtspConnection(Uri URI)
        {
            this.URI = URI;
            Client = new TcpClient(URI.Host, URI.Port);
        }
        public async Task Connect()
        {
            await Client.ConnectAsync()
        }
        public async Task Describe()
        {
            
        }
        public async Task Setup(RtpStream Stream)
        {
            
        }
        public void Play(RtpStream Stream)
        {
            
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}