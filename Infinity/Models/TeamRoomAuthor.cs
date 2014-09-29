using System;

namespace Infinity.Models
{
    public class TeamRoomAuthor
    {
        public Guid Id { get; private set; }
        public string DisplayName { get; private set; }
        public Uri Url { get; private set; }
        public Uri ImageUrl { get; private set; }
    }
}