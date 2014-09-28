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

            Configuration = new TfsClientConfiguration(configuration);

            Project = new ProjectClient(Configuration);
            Git = new GitClient(Configuration);
            TeamRoom = new TeamRoomClient(Configuration);
            UserProfile = new UserProfileClient(Configuration);
        }

        internal TfsClientConfiguration Configuration { get; private set; }

        public ProjectClient Project { get; private set; }
        public GitClient Git { get; private set; }
        public TeamRoomClient TeamRoom { get; private set; }
        public UserProfileClient UserProfile { get; private set; }
    }
}
