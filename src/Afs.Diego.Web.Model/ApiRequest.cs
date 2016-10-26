using Afs.Diego.Common;
using System;

namespace Afs.Diego.Web.Model
{
    public class ApiRequest
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime RequestBeginTime { get; set; }
        public DateTime? RequestEndTime { get; set; }
        public string RequestUrl { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public string HttpMethodText { get; set; }
        public ApiRequestType ApiRequestType { get; set; }
        public string ApiRequestTypeText { get; set; }
        public string ResponseText { get; set; }
        public int? ResponseCode { get; set; }
        public string Error { get; set; }
    }
}
