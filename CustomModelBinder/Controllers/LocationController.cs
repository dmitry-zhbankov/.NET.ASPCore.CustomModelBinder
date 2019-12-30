using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomModelBinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        public IActionResult Get(Point point)
        {
            if (point==null)
            {
                return BadRequest();
            }

            return Json(point);
        }
    }
}