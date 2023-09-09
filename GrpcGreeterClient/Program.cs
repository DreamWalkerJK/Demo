using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var channel = GrpcChannel.ForAddress("https://localhost:7251"))
            {
                var client = new Greeter.GreeterClient(channel);

                var reply = client.SayHello(
                    new HelloRequest { Name = "GreeterClient" });

                Console.WriteLine("Greeting: " + reply.Message);
            }

            Console.ReadKey();
        }
    }
}