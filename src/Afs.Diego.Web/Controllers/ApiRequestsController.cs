using Afs.Diego.Common;
using Afs.Diego.Web.Model;
using Afs.Diego.Web.Services.ApiRequestServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if(EncodeDecodeRequestType.Encode == encodeDecodeRequest.EncodeDecodeRequestType)
            {
                var result = await _apiRequestService.Encode(encodeDecodeRequest.Text);
                return Ok(result);
            } 
            else if(EncodeDecodeRequestType.Decode == encodeDecodeRequest.EncodeDecodeRequestType)
            {
                var result = await _apiRequestService.Decode(encodeDecodeRequest.Text);
                return Ok(result);
            }
            throw new NotSupportedException("The type of request is not supported");
        }
    }
}
