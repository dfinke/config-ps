using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConfigPS
{
    class Program
    {
        static void Main()
        {
            dynamic global = new ConfigPS.Global();

            Console.WriteLine("Count: {0}", global.count);
            Console.WriteLine("Uri:   {0}", global.uri);

            Console.WriteLine("Item1: {0}", global.item1);
            Console.WriteLine("Item50: {0}", global.item50);
            Console.WriteLine("Item51: {0}", global.item51);

            Console.WriteLine("\r\n** processes **");
            foreach (var item in global.processes)
            {
                Console.WriteLine("{0}->{1}", item.ProcessName, item.HandleCount);
            }

            Console.WriteLine("\r\n** json **");
            foreach (var item in global.json)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\n** data **");
            foreach (var item in global.data)
            {
                Console.WriteLine(item);
            }
        }
    }
}