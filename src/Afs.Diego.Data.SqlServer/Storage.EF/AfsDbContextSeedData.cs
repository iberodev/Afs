using Afs.Diego.Data.Entities;
using System;
using System.Linq;

namespace Afs.Diego.Data.SqlServer.Storage.EF
{
    public class AfsDbContextSeedData
    {
        private readonly AfsDbContext _context;

        public AfsDbContextSeedData(AfsDbContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.ApiRequests.Any())
            {
                var testRequest = new ApiRequest
                {
                    ApiRequestType = Common.ApiRequestType.Encode,
                    RequestBeginTime = DateTime.UtcNow,
                    RequestEndTime = DateTime.UtcNow,
                    RequestUrl = "http://thisisatest:8080/encode?text=testdata",
                    Error = null,
                    IsDeleted = false,
                    ResponseCode = 200,
                    ResponseText = "test data encoded would go here",
                    HttpMethod = Common.HttpMethod.Get
                };
                _context.ApiRequests.Add(testRequest);
                _context.SaveChanges();
            }
        }
    }
}
