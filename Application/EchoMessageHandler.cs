using AdsbSupport.UdpServerSample.Core;


namespace AdsbSupport.UdpServerSample.Application;

public class EchoMessageHandler : IMessageHandler
{
    public void ProcessMessage(string message)
    {
        Console.WriteLine(message);
    }
}
