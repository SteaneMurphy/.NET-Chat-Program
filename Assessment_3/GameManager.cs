using System;
using System.Collections.Generic;
using System.Text;
using Windows_Forms_Chat;

namespace Windows_Forms_CORE_CHAT_UGH
{
    internal class GameManager
    {
        List<ClientSocket> clientSockets = new List<ClientSocket>();

        public GameManager(List<ClientSocket> _clientSockets) 
        {
            clientSockets = _clientSockets;
        }

        public void CreateMatch(ClientSocket playerSearching) 
        {
            foreach (ClientSocket client in clientSockets) 
            {
                if (client.stateLooking) 
                {

                }
            }
        }
    }
}
