using Microsoft.AspNetCore.Mvc;

namespace Das.WebApi.Controllers; 

public class ResidentialPropertyController : VersionedApiController {
    [HttpGet]
    public IActionResult Get() {
        return new OkResult();
    }
}