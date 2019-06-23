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

            using (var demo = new Client("127.0.0.1", 9090))
            {
                Console.WriteLine("Hello:");
                var hello = demo.Hello();
                Console.WriteLine(hello);

                Console.WriteLine("Tree traverse:");
                Console.WriteLine("you can uncomment the tree traverse");
                //demo.TreeTraverse(0, 1);

                Console.WriteLine(new string('*', 100));
                Console.WriteLine("Ads by tree (1 rooms) buy:");
                demo.AdsByTreeIndex(4547, 10);

                Console.WriteLine(new string('*', 100));
                Console.WriteLine("Ads by tree (1 rooms) rent:");
                demo.AdsByTreeIndex(4548, 10);

                Console.WriteLine(new string('*', 100));
                Console.WriteLine("Ads by tree (dacha) buy:");
                demo.AdsByTreeIndex(4374, 10);

            }

            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }

    }
}
