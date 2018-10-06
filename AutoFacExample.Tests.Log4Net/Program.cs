using System;
using Log = Log4net.Helper.Logging.Logger;

namespace AutoFacExample.Tests.Log4Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(": : : : : Test Logger Example : : : : :");
            Log.Info("This is a test");
            Log.Xml("Who has a Jenny Butt!");
        }
    }
}
