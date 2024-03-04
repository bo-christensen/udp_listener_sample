using System.Net;
using AdsbSupport.UdpServerSample.Core;
using Microsoft.Extensions.DependencyInjection;


namespace AdsbSupport.UdpServerSample.UdpHost;

public class Program
{
    public static void Main(string[] args)
    {
        var provider = new ServiceCollection()
            .RegisterDependencies()
            .BuildServiceProvider();
        using var client = provider.GetService<IUdpListener>();
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        Task.Run(async () =>
        {
            Console.WriteLine("Receiving UDP: Press any key to stop");
            await client.BeginListen(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9099), tokenSource.Token);
        });
        
        // wait for keypress
        Console.ReadKey();
        tokenSource.Cancel();
    }
}
