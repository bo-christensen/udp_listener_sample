using System.Net;
using System.Net.Sockets;
using System.Text;
using AdsbSupport.UdpServerSample.Core;


namespace AdsbSupport.UdpServerSample.Application;

public class UdpListener : IUdpListener
{
    private readonly IEnumerable<IMessageHandler> messageHandlers;
    private UdpClient udp;
    public UdpListener(IEnumerable<IMessageHandler> messageHandlers)
    {
        this.messageHandlers = messageHandlers ?? throw new ArgumentNullException(nameof(messageHandlers));
    }


    public void Dispose()
    {
        udp.Dispose();
    }


    public async Task BeginListen(IPEndPoint endpoint, CancellationToken stoppingToken)
    {
        udp = new UdpClient(endpoint);
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var received = await udp.ReceiveAsync(stoppingToken);
                // The ADS-B Support UdpDispatcher uses UTF-8 Encoding.
                var message = Encoding.UTF8.GetString(received.Buffer);
                foreach (var handler in messageHandlers)
                {
                    handler.ProcessMessage(message);
                }
            }

            catch (Exception e) when (e is not OperationCanceledException)
            {
                Console.WriteLine($"Error occurred while receiving UDP message: {e.Message}");
            }

        }
    }
    
}
