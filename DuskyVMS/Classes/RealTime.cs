using System;
using System.Net.Sockets;

namespace DuskyVMS.Classes.RealTime;

public class RtspSession
{
    public Uri Uri { get; }
    public RtpSession[] RtpSessions { get; }
    public RtspSession(Uri Uri)
    {
        this.Uri = Uri;
        //Connect, get list of streams...
        //Populate RtpSessions...
    }
    public void Close()
    {
        //Teardown all RtpSessions...
        //Close RtspSession...
    }
}

public class RtpSession
{

    public NetworkStream NetworkStream { get; }
    public RtpStreamTypes RtpStreamType { get; }
    public RtpSession(NetworkStream NetworkStream, RtpStreamTypes RtpStreamType)
    {
        this.NetworkStream = NetworkStream;
        this.RtpStreamType = RtpStreamType;
    }
    public void Play()
    {
        
    }
    public void Pause()
    {
        
    }
    public void Teardown()
    {
        
    }
}

public enum RtpStreamTypes
{
    Video,
    Audio,
    Metadata
}