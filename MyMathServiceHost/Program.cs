using System;
using System.ServiceModel;

namespace MyMathServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                svcHost = new ServiceHost(typeof(MyMathServiceLib.MathService));
                svcHost.Open();

                Console.WriteLine("\n\nService is running at following address:");
                Console.WriteLine("\nhttps://DESKTOP-OMP50VJ:9001/MathService");
                Console.WriteLine("\nnet.tcp://DESKTOP-OMP50VJ:9002/MathService");
            }
            catch (Exception ex)
            {
                svcHost = null;
                Console.WriteLine("\n\nService could not start...\n\n Error : [" + ex.Message + "]");
            }

            if(svcHost != null)
            {
                Console.WriteLine("\n\nPress any key to stop : ");
                Console.ReadKey();
                svcHost.Close();
                svcHost = null;
            }
        }
    }
}
