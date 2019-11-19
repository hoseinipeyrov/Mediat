using Microsoft.AspNetCore.Mvc;

namespace Mediat.Controllers
{
    public class ApiController : ControllerBase
    {

        protected new IActionResult Response(object result = null)
        {
            //if (IsValidOperation())
            if (true)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = "" /*_notifications.GetNotifications().Select(n => n.Value)*/
            });
        }
        protected new IActionResult Response(bool state, object result = null)
        {
            if (state)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = ""
            });
        }
    }
}
