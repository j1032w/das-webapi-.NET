using Microsoft.AspNetCore.Mvc;

namespace Das.WebApi.Controllers {

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VersionedApiController : ControllerBase {
    }
}
