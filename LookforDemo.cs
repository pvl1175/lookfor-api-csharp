﻿using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;
using static Api;

namespace CreditsCSAPIDemo
{
    public class LookforDemo : IDisposable
    {
        TSocket transport;
        TBinaryProtocol protocol;
        Client client;

        public LookforDemo(string ip, int port)
        {
            transport = new TSocket(ip, port);
            protocol = new TBinaryProtocol(transport);
            client = new Client(protocol);
            transport.Open();
        }

        public void Dispose()
        {
            transport.Close();
        }

        public string Hello()
        {
            return client.Hello();
        }

        public void TreeTraverse(int index, int printLayer)
        {
            var list = client.TreeChildren(index);
            foreach (var item in list)
            {
                Console.WriteLine($"{new string('\t', printLayer)} {item.Id}.{item.Name}");
                TreeTraverse(item.Id, printLayer + 1);
            }
        }

        public void AdsByTreeIndex(int index, short rowsCount)
        {
            var list = client.AdsByTree(index, rowsCount);
            foreach (var ad in list)
            {
                Console.WriteLine($"{ad.Id}\t{ad.Title.PadRight(40, ' ')}\t{ad.Price}\t{ad.AvitoTime}\t{ad.Address.PadRight(80, ' ')}\t{ad.OwnerPhone}");
            }
            Console.WriteLine("...");
            foreach (var ad in list)
            {
                Console.WriteLine($"{ad.OwnerPhone}\t{ad.OwnerName.PadRight(50, ' ')}\t{ad.PhoneInfo.PadRight(80, ' ')}");
            }
        }
    }
}
