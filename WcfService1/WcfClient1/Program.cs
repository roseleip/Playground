using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WcfClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfService1Proxy.Service1Client proxy = new WcfClient1.WcfService1Proxy.Service1Client();
            string data = proxy.GetData(99);
            Console.WriteLine("Data is " + data);
        }
    }
}

