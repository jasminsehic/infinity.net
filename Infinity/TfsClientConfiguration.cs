using System;
using System.Net;

namespace Infinity
{
    /// <summary>
    /// Configuration for a <see cref="TfsClient"/> instance.
    /// </summary>
    public class TfsClientConfiguration
    {
        /// <summary>
        /// Configuration for a <see cref="TfsClient"/> instance.
        /// </summary>
        public TfsClientConfiguration()
        {
        }

        internal TfsClientConfiguration(TfsClientConfiguration original)
        {
            Url = original.Url;
            Credentials = new NetworkCredential(original.Credentials.UserName, original.Credentials.Password, original.Credentials.Domain);
            UserAgent = original.UserAgent;
        }

        /// <summary>
        /// The URI of the Project Collection to connect to.
        /// 
        /// For Visual Studio Online, this will look like
        /// <code>https://accountname.visualstudio.com/DefaultCollection</code>.
        /// For on-premises Team Foundation Server instances, this will look
        /// like <code>http://tfsserver:8080/tfs/DefaultCollection</code>.
        /// </summary>
        public Uri Url
        {
            get;
            set;
        }

        /// <summary>
        /// The credentials to authenticate with.  For Visual Studio Online,
        /// this should be the username of the "alternate credentials"
        /// that you have configured for your account.  For on-premises
        /// servers, you may specify credentials or use default.
        /// </summary>
        public NetworkCredential Credentials
        {
            get;
            set;
        }

        /// <summary>
        /// The user-agent string to include on the HTTP request.
        /// </summary>
        public string UserAgent
        {
            get;
            set;
        }

        /// <summary>
        /// The OAuth Access token used to access VSO. If this is specified it will take
        /// precendence over <see cref="Credentials" /> for VSO.
        /// </summary>
        public string OAuthToken
        {
            get;
            set;
        }
    }
}