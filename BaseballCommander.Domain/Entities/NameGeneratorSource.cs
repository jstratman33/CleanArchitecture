using System;

namespace BaseballCommander.Domain.Entities
{
    public class NameGeneratorSource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime TimeEntered { get; set; }
    }
}