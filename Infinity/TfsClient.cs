using System.Runtime.CompilerServices;
using Infinity.Clients;
using Infinity.Util;

[assembly: InternalsVisibleTo("Infinity.Tests")]
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
        public TfsClient(TfsClientConfiguration configuration) :
            this(new TfsClientExecutor(configuration))
        {
        }

        internal TfsClient(ITfsClientExecutor executor)
        {
            Assert.NotNull(executor, "executor");

            Executor = executor;

            Project = new ProjectClient(Executor);
            Git = new GitClient(Executor);
            Team = new TeamClient(Executor);
            TeamRoom = new TeamRoomClient(Executor);
        }

        private ITfsClientExecutor Executor { get; set; }

        /// <summary>
        /// Information about Team Projects.
        /// </summary>
        public ProjectClient Project { get; private set; }

        /// <summary>
        /// Information about Git repositories, commits, references, etc.
        /// </summary>
        public GitClient Git { get; private set; }

        /// <summary>
        /// Information about project teams.
        /// </summary>
        public TeamClient Team { get; private set; }

        /// <summary>
        /// Information about Team Rooms.
        /// </summary>
        public TeamRoomClient TeamRoom { get; private set; }
    }
}
