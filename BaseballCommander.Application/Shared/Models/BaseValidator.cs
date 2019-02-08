using System.Collections.Generic;

namespace BaseballCommander.Application.Shared.Models
{
    public class BaseValidator
    {
        public bool IsValid { get; protected set; } = true;
        public List<string> Messages { get; protected set; } = new List<string>();
    }
}