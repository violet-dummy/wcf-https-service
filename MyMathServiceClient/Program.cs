using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace MyMathServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your choice : 1. Add, 2.Subtract, 3. Multiply, 4. Divide");
            int op = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter connect method : a. TCP, b. HTTP");
            string meth = Console.ReadLine();

            Console.WriteLine("\nEnter first num : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter second number : ");
            int b = Convert.ToInt32(Console.ReadLine());
            int result = 0;

            try
            {
                switch (meth)
                {
                    case "a":
                        result = TcpMethod(a, b, op);
                        break;

                    case "b":
                        result = HttpMethod(a, b, op);
                        break;                        
                }
               
                Console.WriteLine("\nResult = " + result);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nThere was an error while calling Service [" + ex.Message + "]");
            }
        }

        private static int TcpMethod(int num1, int num2, int op)
        {
            int result = 0;
            Console.WriteLine("\nUsing TCP binding :");
            MathServiceClient mathClientTcp = new MathServiceClient("NetTcpBinding_IMathService");

            switch (op)
            {
                case 1:
                    result = mathClientTcp.Add(num1, num2);
                    break;
                case 2:
                    result = mathClientTcp.Subtract(num1, num2);
                    break;
            }

            return result;
        }

        private static int HttpMethod(int num1, int num2, int op)
        {
            int result = 0;
            Console.WriteLine("\nUsing HTTP binding :");
            MathServiceClient mathClientHttp = new MathServiceClient("BasicHttpBinding_IMathService");

            //Added to suppress certificate validation at client side.
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => ValidateCert(sender, certificate, chain, sslPolicyErrors);

            switch (op)
            {
                case 1:
                    result = mathClientHttp.Add(num1, num2);
                    break;
                case 2:
                    result = mathClientHttp.Subtract(num1, num2);
                    break;
            }

            return result;
        }

        protected static bool ValidateCert(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
        {

            // set a list of servers for which cert validation errors will be ignored
            var overrideCerts = new string[]
            {
            "localhost"
            };

            // if the server is in the override list, then ignore any validation errors
            var serverName = cert.Subject.ToLower();
            if (overrideCerts.Any(overrideName => serverName.Contains(overrideName)))
            {
                return true;
            }
            else
            {
                return false;
            }

            // otherwise use the standard validation results
            //return errors == SslPolicyErrors.None;
        }

    }
}
