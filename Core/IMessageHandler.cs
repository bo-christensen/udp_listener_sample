namespace AdsbSupport.UdpServerSample.Core;

public interface IMessageHandler
{
    public void ProcessMessage(string message);
}
