using System;
using System.Threading.Tasks;

namespace Infinity.Models
{
    public class UserProfile
    {
        public Guid Id { get; private set; }
        public int Revision { get; private set; }
        public string DisplayName { get; private set; }
        public Guid PublicAlias { get; private set; }
        public string EmailAddress { get; private set; }
        public int CoreRevision { get; private set; }
        public DateTime TimeStamp { get; private set; }
    }
}