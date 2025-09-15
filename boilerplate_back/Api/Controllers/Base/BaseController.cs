using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Base
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleResult<T>(T result) where T : class
        {
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        protected IActionResult HandleResult<T>(IEnumerable<T> result) where T : class
        {
            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }

        protected IActionResult HandleError(string message, int statusCode = 400)
        {
            return StatusCode(statusCode, new { message });
        }
    }
}
