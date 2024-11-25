﻿using System.Net.Sockets;

namespace Windows_Forms_Chat
{
    public class ClientSocket
    {
        //add other attributes to this, e.g username, what state the client is in etc
        public Socket socket;
        public const int BUFFER_SIZE = 2048;
        public byte[] buffer = new byte[BUFFER_SIZE];
        public string username;
        public bool away = false;
        public string awayMessage = "";
        public bool mod = false;
    }
}
