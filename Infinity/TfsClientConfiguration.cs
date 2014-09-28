namespace Infinity
{
    public class TfsClientConfiguration
    {
        public TfsClientConfiguration()
        {
        }

        internal TfsClientConfiguration(TfsClientConfiguration original)
        {
            Uri = original.Uri;
            Username = original.Username;
            Password = original.Password;
            UserAgent = original.UserAgent;
        }

        public string Uri
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string UserAgent
        {
            get;
            set;
        }
    }
}