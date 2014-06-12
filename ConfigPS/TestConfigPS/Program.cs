using System;

namespace TestConfigPS
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Count: {0}", ConfigPS.Global.Get<int>("count"));
            Console.WriteLine("Uri:   {0}", ConfigPS.Global.Get<Uri>("uri"));

            for (var idx = 1; idx < 11; idx += 1)
            {
                Console.WriteLine("Item{0}: {1}", idx, ConfigPS.Global.Get<int>("item" + idx));
            }

            Console.WriteLine("processes: {0}", ConfigPS.Global.Get<string>("processes"));
            Console.WriteLine("services:  {0}", ConfigPS.Global.Get<string>("services"));
        }
    }
}