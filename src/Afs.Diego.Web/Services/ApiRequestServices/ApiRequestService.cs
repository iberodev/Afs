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

        public async Task<string> EncodeDecodeAsync(string text, ApiRequestType apiRequestType)
        {
            using (var httpClient = new HttpClient())
            {
                DateTime timeBegin = DateTime.UtcNow;
                httpClient.BaseAddress = new Uri(_mashapeOptions.UrlDecode);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add(Constants.ApiSettings.HEADER_MASHAPE_X_KEY, _mashapeOptions.XMashapeKey);
                httpClient.DefaultRequestHeaders.Add(Constants.ApiSettings.HEADER_ACCEPT, Constants.ApiSettings.HEADER_ACCEPT_TEXT_PLAIN);
                
                var relativePath = ApiRequestType.Encode == apiRequestType? $"/encode?text={text}" : $"/decode?text={text}";

                var response = await httpClient.GetAsync(relativePath);

                var textResponse = await response.Content.ReadAsStringAsync();

                await _apiRequestRepository.AddApiRequestAsync(new Data.Entities.ApiRequest
                {
                    ApiRequestType = apiRequestType,
                    HttpMethod = Common.HttpMethod.Get,
                    RequestBeginTime = timeBegin,
                    RequestEndTime = DateTime.UtcNow,
                    IsDeleted = false,
                    RequestUrl = response.RequestMessage.RequestUri.ToString(),
                    Error = response.IsSuccessStatusCode ? null : response.ReasonPhrase,
                    ResponseText = textResponse,
                    ResponseCode = (int)response.StatusCode
                });
                return textResponse;
            }
        }

        public async Task<IEnumerable<ApiRequest>> GetAllApiRequestsAsync()
        {
            var requestEntities = await _apiRequestRepository.GetApiRequestsAsync();
            var requestServiceModels = requestEntities.Select(r => _autoMapper.Map<ApiRequest>(r));
            return requestServiceModels;
        }
    }
}
