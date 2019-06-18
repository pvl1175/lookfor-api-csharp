using System;
using System.Diagnostics;
using System.IO;
using Thrift.Protocol;
using Thrift.Transport;
using static Api;

namespace CreditsCSAPIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lookfor9 Simple Demo");

            using (var transport = new TSocket("127.0.0.1", 9090))
            {
                using (var protocol = new TBinaryProtocol(transport))
                {
                    using (var client = new Client(protocol))
                    {
                        transport.Open();

                        Console.WriteLine(client.Hello());
                        Console.WriteLine(client.PhoneInfo("9196315221"));

                        var list = client.GetActiveProxies();
                        Console.WriteLine(list.Count);
                    }
                }
            }

            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }

    }
}
