using Afs.Diego.Web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Afs.Diego.Web.Services.ApiRequestServices
{
    public interface IApiRequestService
    {
        Task<IEnumerable<ApiRequest>> GetAllApiRequestsAsync();

        Task<string> Encode(string text);

        Task<string> Decode(string text);
    }
}
