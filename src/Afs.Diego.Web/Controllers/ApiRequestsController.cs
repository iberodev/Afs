using Afs.Diego.Web.Model;
using Afs.Diego.Web.Services.ApiRequestServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Afs.Diego.Web.Controllers
{
    [Route("api/[controller]")]
    public class ApiRequestsController : Controller
    {
        private readonly IApiRequestService _apiRequestService;

        public ApiRequestsController(IApiRequestService apiRequestService)
        {
            _apiRequestService = apiRequestService;
        }


        //GET api/apirequest
        [HttpGet]
        public async Task<IActionResult> GetAllApiRequestsAsync()
        {
            var requests = await _apiRequestService.GetAllApiRequestsAsync();
            return Ok(requests);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRequestAsync([FromBody]EncodeDecodeRequest encodeDecodeRequest)
        {
            var result = 
                await _apiRequestService.EncodeDecodeAsync(encodeDecodeRequest.Text, encodeDecodeRequest.ApiRequestType);
            return Ok(result);
        }
    }
}
