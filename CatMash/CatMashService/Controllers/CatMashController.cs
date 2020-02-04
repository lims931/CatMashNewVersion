using CatMashService.Models;
using CatMashService.Services;
using Microsoft.AspNetCore.Mvc;
using CatMashService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatMashController : ControllerBase
    {
        private readonly ICatMashServices _catMashServices;

        public CatMashController(ICatMashServices catMashServices)
        {
            _catMashServices = catMashServices;
        }

        [HttpGet]
        [Route("addmatch")]
        public IActionResult AddMatch([FromBody]Match match)
        {
            var response = _catMashServices.AddMatch(match);
            return Ok(response);
        }

        [HttpGet]
        [Route("opponents")]
        public IActionResult GetOpponents()
        {
            var response = _catMashServices.GetOpponents();
            return Ok(response);
        }

        [HttpGet]
        [Route("allcats")]
        public IActionResult GetAllCatsWithResults()
        {
            var response = _catMashServices.GetAllCatsWithResults();
            return Ok(response);
        }
    }
}
