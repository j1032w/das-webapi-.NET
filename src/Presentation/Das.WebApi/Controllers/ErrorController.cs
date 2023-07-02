using Microsoft.AspNetCore.Mvc;

namespace Das.WebApi.Controllers; 

[ApiController]
public class ErrorController : ControllerBase {
    [Route("/error")]
    [HttpGet]
    public IActionResult Error() {
        return Problem();
    }
}


