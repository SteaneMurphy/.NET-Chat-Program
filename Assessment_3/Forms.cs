using Windows_Forms_Chat;

namespace Windows_Forms_CORE_CHAT_UGH
{
    public class Forms
    {
        public PreLoginForm preLoginForm;
        public LoginForm loginForm;
        public RegistrationForm registrationForm;
        public ConnectionForm connectionForm;
        public ChatForm chatForm;

        public Forms(TCPChatClient client, ConnectionForm _connectionForm, ChatForm _chatForm) 
        {
            preLoginForm = new PreLoginForm(client);
            loginForm = new LoginForm(client);
            registrationForm = new RegistrationForm(client);
            connectionForm = _connectionForm;
            chatForm = _chatForm;
        }
    }
}
