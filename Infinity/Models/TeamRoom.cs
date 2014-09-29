using System;

namespace Infinity.Models
{
    public class TeamRoom
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public DateTime LastActivity { get; internal set; }
        public bool IsClosed { get; internal set; }
        public TeamRoomAuthor CreatedBy { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public bool HasAdminPermissions { get; internal set; }
        public bool HasReadWritePermissions { get; internal set; }
    }
}
