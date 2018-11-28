using System;

namespace CleanArchitecture.Core.Entities
{
    public class BaseEntity
    {
        public DateTime AddedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
