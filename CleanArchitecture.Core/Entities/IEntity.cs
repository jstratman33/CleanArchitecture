using System;

namespace CleanArchitecture.Domain.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime AddedTime { get; set; }
        DateTime ModifiedTime { get; set; }
        Guid Guid { get; set; }
    }
}