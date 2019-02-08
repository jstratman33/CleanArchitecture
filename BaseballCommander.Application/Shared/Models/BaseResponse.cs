using System.Collections.Generic;

namespace BaseballCommander.Application.Shared.Models
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }

        public BaseResponse()
        {
            Messages = new List<string>();
        }
    }

    public class BaseResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
