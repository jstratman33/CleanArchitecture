using System;

namespace CleanArchitecture.Core.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
