using Microsoft.AspNetCore.Mvc;

namespace CustomModelBinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        [Route("{base64str}")]
        public IActionResult Get(Person person)
        {
            if (person==null)
            {
                return BadRequest();
            }

            return Json(person);
        }
    }
}