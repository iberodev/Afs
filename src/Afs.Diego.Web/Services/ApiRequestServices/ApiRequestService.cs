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
using Afs.Diego.Common.TypeMapping;
using System.Linq;

namespace Afs.Diego.Web.Services.ApiRequestServices
{
    public class ApiRequestService : IApiRequestService
    {
        private readonly MashapeOptions _mashapeOptions;
        private readonly IApiRequestRepository _apiRequestRepository;
        private readonly IAutoMapper _autoMapper;

        public ApiRequestService(
            IOptions<MashapeOptions> mashapeOptions,
            IApiRequestRepository apiRequestRepository,
            IAutoMapper autoMapper)
        {
            if (mashapeOptions == null || mashapeOptions.Value == null)
            {
                throw new SettingsNotFoundException(
                    $"Mashape settings section not found in {Constants.AppSettings.APP_SETTINGS_FILE_FULLNAME}");
            }
            _mashapeOptions = mashapeOptions.Value;
            _apiRequestRepository = apiRequestRepository;
            _autoMapper = autoMapper;
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

        public async Task<IEnumerable<ApiRequest>> GetAllApiRequestsAsync()
        {
            var requestEntities = await _apiRequestRepository.GetApiRequestsAsync();
            var requestServiceModels = requestEntities.Select(r => _autoMapper.Map<ApiRequest>(r));
            return requestServiceModels;
        }
    }
}
