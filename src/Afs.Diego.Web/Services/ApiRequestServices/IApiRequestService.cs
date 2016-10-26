using Afs.Diego.Common;
using Afs.Diego.Web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Afs.Diego.Web.Services.ApiRequestServices
{
    public interface IApiRequestService
    {
        Task<IEnumerable<ApiRequest>> GetAllApiRequestsAsync();

        Task<string> EncodeDecodeAsync(string text, ApiRequestType apiRequestType);
    }
}
