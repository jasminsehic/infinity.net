using System;

namespace Infinity.Models
{
    public class TeamRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastActivity { get; set; }
        public bool IsClosed { get; set; }
        public Guid CreatorUserTfId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool HasAdminPermissions { get; set; }
        public bool HasReadWritePermissions { get; set; }
    }
}