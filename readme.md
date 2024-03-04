# UdpListener Example App
A simple UDP Listener which listens to a specific IPEndPoint and then processes the incoming messages.

## Running the sample app
Edit the IP-Address and Port in the `UdpHost/Program.cs` file then compile and run the program.

> Requires .NET 8.0  
> https://dotnet.microsoft.com/en-us/download

## Project Structure
The project has basic interfaces and POCOs in the `Core` class library.  
Functional parts are in the `Application` class library  
The entry-point is in `UdpHost`

The app creates an instance of the `UdpListener` via `Microsoft.Extensions.DependencyInjection` and simply listens for datagrams on the provided IP and port until cancellation is requested.

## Inquiries
Contact ADS-B Support if you've any questions regarding the UDP CSV-format integration.
