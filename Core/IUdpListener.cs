using System.Net;


namespace AdsbSupport.UdpServerSample.Core;

public interface IUdpListener : IDisposable
{
    public Task BeginListen(IPEndPoint endpoint, CancellationToken stoppingToken);
}
