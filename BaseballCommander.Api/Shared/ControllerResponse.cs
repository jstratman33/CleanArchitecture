using System.Collections.Generic;

namespace BaseballCommander.Api.Shared
{
    public class ControllerResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }

        public ControllerResponse()
        {
            Messages = new List<string>();
        }
    }

    public class ControllerResponse<T> : ControllerResponse
    {
        public T Data { get; set; }
    }
}
