using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Afs.Diego.Web.Model;
using Afs.Diego.Data.Repository;
using System.Net.Http;
using Afs.Diego.Data.AppSettings;
using Microsoft.Extensions.Options;
using Afs.Diego.Data.Exceptions;
using Afs.Diego.Common;

namespace Afs.Diego.Web.Services.ApiRequestServices
{
    public class ApiRequestService : IApiRequestService
    {
        private readonly MashapeOptions _mashapeOptions;
        private readonly IApiRequestRepository _apiRequestRepository;

        public ApiRequestService(
            IOptions<MashapeOptions> mashapeOptions,
            IApiRequestRepository apiRequestRepository)
        {
            if (mashapeOptions == null || mashapeOptions.Value == null)
            {
                throw new SettingsNotFoundException(
                    $"Mashape settings section not found in {Constants.AppSettings.APP_SETTINGS_FILE_FULLNAME}");
            }
            _mashapeOptions = mashapeOptions.Value;
            _apiRequestRepository = apiRequestRepository;
        }

        public Task<ApiRequest> AddApiRequestAsync(ApiRequest apiRequest)
        {
            throw new NotImplementedException();
        }

        public Task<string> Decode(string text)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_mashapeOptions.UrlDecode);
                httpClient.DefaultRequestHeaders.Add(Constants.ApiSettings.HEADER_MASHAPE_X_KEY, _mashapeOptions.XMashapeKey);
                httpClient.DefaultRequestHeaders.Add(Constants.ApiSettings.HEADER_ACCEPT, Constants.ApiSettings.HEADER_ACCEPT_TEXT_PLAIN);

                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, )

                //httpClient.SendAsync()
            }
            return null;
        }

        public Task<string> Encode(string text)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiRequest>> GetAllApiRequestsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
