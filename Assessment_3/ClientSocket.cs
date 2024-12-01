using System.Net.Sockets;

namespace Windows_Forms_Chat
{
    public class ClientSocket
    {
        /*
            Each connected client socket variables are stored in this object.
            A client's username, away and moderator status, and away message are also stored
            here.
        */
        public Socket socket;
        public const int BUFFER_SIZE = 2048;
        public byte[] buffer = new byte[BUFFER_SIZE];

        //Login
        public string username;
        public string email;
        public string password;

        //Chat
        public bool away = false;
        public string awayMessage = "";
        public bool mod = false;

        //Client State
        public bool stateLogin = true;
        public bool stateChatting = false;
        public bool statePlaying = false;
    }
}
