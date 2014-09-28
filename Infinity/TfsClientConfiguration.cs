using System;

namespace Infinity
{
    public class TfsClientConfiguration
    {
        public TfsClientConfiguration()
        {
        }

        internal TfsClientConfiguration(TfsClientConfiguration original)
        {
            Url = original.Url;
            Username = original.Username;
            Password = original.Password;
            UserAgent = original.UserAgent;
        }

        public Uri Url
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