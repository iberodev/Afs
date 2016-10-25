using Afs.Diego.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Afs.Diego.Data.Entities;
using Afs.Diego.Data.SqlServer.Storage.EF;
using Microsoft.EntityFrameworkCore;

namespace Afs.Diego.Data.SqlServer.Repository
{
    public class ApiRequestRepository : IApiRequestRepository
    {
        private readonly AfsDbContext _context;
        public ApiRequestRepository(AfsDbContext context)
        {
            _context = context;
        }
        public async Task AddApiRequestAsync(ApiRequest apiRequest)
        {
            _context.ApiRequests.Add(apiRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApiRequest>> GetApiRequestsAsync()
        {
            var requests = await _context.ApiRequests
                .ToListAsync();
            return requests;
        }
    }
}
