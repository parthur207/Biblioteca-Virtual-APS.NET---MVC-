using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Virtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Livro_Controller : ControllerBase
    {

        [HttpGet]
        [Authorize()]
        public IActionResult Index()
        {


            return View();
        }
    }
}
