using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWebTest.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Get([FromServices] Microsoft.Graph.GraphServiceClient graph)
        {
            string userId = "{ USER IN YOUR ORG }";

            var request = await graph.Users[userId].Photo.Content
                .Request()
                .WithAppOnly()
                .GetAsync();

            return Ok();
        }
    }

}
