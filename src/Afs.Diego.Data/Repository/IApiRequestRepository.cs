using Afs.Diego.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Afs.Diego.Data.Repository
{
    public interface IApiRequestRepository
    {
        Task<IEnumerable<ApiRequest>> GetApiRequestsAsync();

        Task AddApiRequestAsync(ApiRequest apiRequest);
    }
}
