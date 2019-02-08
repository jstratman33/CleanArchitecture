using System;
using System.Collections.Generic;

namespace BaseballCommander.Domain.Entities
{
    public class User
    {
        public User()
        {
            TeamPermissions = new HashSet<TeamPermission>();
        }

        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public ICollection<TeamPermission> TeamPermissions { get; }
    }
}