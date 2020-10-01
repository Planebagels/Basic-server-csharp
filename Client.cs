using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Network_
{
    

    class Client
    {
        char a = 'a';

        public int id;
        public TCP tcp;
        public static int dataBufferSize = 4096;//4 mb 
        
        public Client(int _clientID)
        {
            id = _clientID;
            tcp = new TCP(id);
        }

        public class TCP
        {
            public TcpClient socket;

            private readonly int id;
            private NetworkStream Stream;
            private byte[] get_buffer;

            //to assign the id field I'm using a constructor which takes in an int
            public TCP(int _id)
            {
                id = _id;
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                Stream = socket.GetStream();

                get_buffer = new byte[dataBufferSize];

                Stream.BeginRead(get_buffer, 0, dataBufferSize, get_callback, null);//null is the object state




            }

            private void get_callback(IAsyncResult _result)
            {

                try
                {
                    int _byteLength = Stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {
                        //TODO: disconnect
                        return;


                    }


                    byte[] _data = new byte[_byteLength];
                    Array.Copy(get_buffer, _data, _byteLength);
                    //TODO: handle data
                    Stream.BeginRead(get_buffer, 0, dataBufferSize, get_callback, null);
                
                }
                catch (Exception _ex)
                {
                    Console.WriteLine("error getting TCP data Error Code: TCPDP ");
                    
                }





            }
        }


    }
}
