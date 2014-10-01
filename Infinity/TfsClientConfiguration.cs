using System;

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
            Username = original.Username;
            Password = original.Password;
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
        /// The username to authenticate with.  For Visual Studio Online,
        /// this should be the username of the "alternate credentials"
        /// that you have configured for your account.  For on-premises
        /// servers, you may leave this blank to perform Integrated
        /// Windows Authentication, or you may set this to a domain user.
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// The password to authenticate with.
        /// </summary>
        public string Password
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
    }
}