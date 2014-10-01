using Infinity.Clients;
using Infinity.Util;

namespace Infinity
{
    /// <summary>
    /// The TFS client API.
    /// </summary>
    public class TfsClient
    {
        /// <summary>
        /// Create a new TFS client API.
        /// </summary>
        /// <param name="configuration">The configuration for the TFS server.</param>
        public TfsClient(TfsClientConfiguration configuration)
        {
            Assert.NotNull(configuration, "configuration");
            Assert.NotNull(configuration.Url, "configuration.Url");

            Executor = new TfsClientExecutor(configuration);

            Project = new ProjectClient(Executor);
            Git = new GitClient(Executor);
            TeamRoom = new TeamRoomClient(Executor);
            UserProfile = new UserProfileClient(Executor);
        }

        private TfsClientExecutor Executor { get; set; }

        /// <summary>
        /// The configuration used for this client.
        /// </summary>
        public TfsClientConfiguration Configuration
        {
            get
            {
                return Executor.Configuration;
            }
        }

        /// <summary>
        /// Information about Team Projects.
        /// </summary>
        public ProjectClient Project { get; private set; }

        /// <summary>
        /// Information about Git repositories, commits, references, etc.
        /// </summary>
        public GitClient Git { get; private set; }

        /// <summary>
        /// Information about Team Rooms.
        /// </summary>
        public TeamRoomClient TeamRoom { get; private set; }

        /// <summary>
        /// Information about users.
        /// </summary>
        public UserProfileClient UserProfile { get; private set; }
    }
}
