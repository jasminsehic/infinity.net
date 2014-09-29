using Infinity.Clients;
using Infinity.Util;

namespace Infinity
{
    public class TfsClient
    {
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

        public TfsClientConfiguration Configuration
        {
            get
            {
                return Executor.Configuration;
            }
        }

        public ProjectClient Project { get; private set; }
        public GitClient Git { get; private set; }
        public TeamRoomClient TeamRoom { get; private set; }
        public UserProfileClient UserProfile { get; private set; }
    }
}
