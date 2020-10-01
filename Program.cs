using System;

namespace Network_
{
    class Program
    {
        static void Main(string[] args)
        {
            //set title of console app
            Console.Title = "My Server";

            Server.Start(50, 26950);//start server, port number

            Console.ReadKey();//prevents console from closing
        }
    }
}
