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
    }
}
