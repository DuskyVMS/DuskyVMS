using System.Net;
using System.Net.Sockets;
using DuskyVMS.Definitions;

namespace DuskyVMS.Protocols.RTP
{
    public class RtspConnection : IDisposable
    {
        private Uri URI;
        public RtpStream[] RtpStreams = Array.Empty<RtpStream>();
        private TcpClient Client;
        private uint CSeq = 0;
        private StreamReader SR;
        private StreamWriter SW;
        private string? Username;
        private string? Password;
        private Dictionary<DateTime, Func<string, Task>> RecieveCallbacks = new();
        private const uint CallbackTimeoutSeconds = 5;
        public RtspConnection(Uri URI, string? Username = null, string? Password = null)
        {
            if (URI.Scheme != "rtsp") throw new Exception("Scheme must be RTSP.");
            this.URI = URI;
            this.Username = Username;
            this.Password = Password;
            Client = new TcpClient();
        }
        public async Task ConnectAsync()
        {
            await Client.ConnectAsync(URI.Host, URI.Port == -1 ? 554 : URI.Port);
            SR = new(Client.GetStream());
            SW = new(Client.GetStream());
            DispatchLoop();
        }
        private async void DispatchLoop()
        {
            while (true)
            {
                string message = await SR.ReadToEndAsync();
                foreach (var callback in RecieveCallbacks)
                {
                    if ((DateTime.Now - callback.Key).TotalSeconds >= CallbackTimeoutSeconds)
                    {
                        RecieveCallbacks.Remove(callback.Key);
                        continue;
                    }
                    callback.Value.Invoke(message);
                }
            }
            
            //
        }
        private async Task SendAsync(Uri Uri, Keyword Keyword, Header[]? Headers = null)
        {
            string message = string.Empty;
            message += $"{Keyword} {Uri} RTSP/1.0\r\n";
            message += $"CSeq: {CSeq++}";
            if (Headers != null)
            {
                message += "\r\n";
                foreach (Header header in Headers)
                {
                    message += $"{header.Key}: {header.Value}";
                }
            }
            await SW.WriteAsync(message + "\r\n\r\n");
            await SW.FlushAsync();
        }
        public async Task OptionsAsync()
        {
            await SendAsync(URI, Keyword.OPTIONS);
        }
        public async Task DescribeAsync()
        {
            await SendAsync(URI, Keyword.DESCRIBE);
        }
        public async Task SetupAsync(RtpStream Stream)
        {
            
        }
        public void PlayAsync(RtpStream Stream)
        {
            
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        private enum Keyword
        {
            OPTIONS,
            DESCRIBE,
            SETUP,
            PLAY,
            TEARDOWN
        }
        private struct Header
        {
            public string Key;
            public string Value;
        }
    }
}