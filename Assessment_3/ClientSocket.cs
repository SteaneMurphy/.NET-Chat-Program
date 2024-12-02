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
        public bool stateLogin = false;
        public bool stateChatting = false;
        public bool stateLooking = false;
        public bool statePlaying = false;

        public void SetState(string state) 
        {
            switch (state) 
            {
                case "stateLogin":
                    stateLogin = true;
                    stateChatting = false;
                    stateLooking = false;
                    statePlaying = false;
                    break;
                case "stateChatting":
                    stateLogin = false;
                    stateChatting = true;
                    stateLooking = false;
                    statePlaying = false;
                    break;
                case "stateLooking":
                    stateLogin = false;
                    stateChatting = false;
                    stateLooking = true;
                    statePlaying = false;
                    break;
                case "statePlaying":
                    stateLogin = false;
                    stateChatting = false;
                    stateLooking = false;
                    statePlaying = true;
                    break;
            }
        }
    }
}
