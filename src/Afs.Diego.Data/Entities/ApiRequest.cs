using Afs.Diego.Common;
using System;

namespace Afs.Diego.Data.Entities
{
    public class ApiRequest
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime RequestBeginTime { get; set; }
        public DateTime RequestEndTime { get; set; }
        public string RequestUrl { get; set; }
        public HttpMethod HttpMethod { get; set; } = HttpMethod.Get;
        public ApiRequestType ApiRequestType { get; set; } = ApiRequestType.Decode;
        public string ResponseText { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int ResponseCode { get; set; }
        public string Error { get; set; }
    }
}
