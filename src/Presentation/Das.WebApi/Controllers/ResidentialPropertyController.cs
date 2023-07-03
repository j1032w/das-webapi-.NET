using Das.Application.ResidentialProperties;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Das.WebApi.Controllers;

public class ResidentialPropertyController : VersionedApiController {
    private readonly IResidentialPropertyService _residentialPropertyService;

    public ResidentialPropertyController(IResidentialPropertyService residentialPropertyService) {
        _residentialPropertyService = residentialPropertyService;
    }

    #region Residential Property
    [HttpGet("{id}")]
    [SwaggerOperation("Get a residential property by Id", "")]
    public async Task<ActionResult<ResidentialPropertyDto>> GetAsync(int id) {
        return await _residentialPropertyService.GetByIdAsync(id);
    }

    [HttpPost("search")]
    [SwaggerOperation("Search residential properties", "")]
    public IActionResult Search() {
        return new OkResult();
    }


    [HttpPost]
    [SwaggerOperation("Create a new residential property", "")]
    public IActionResult Post() {
        return new OkResult();
    }

    [HttpPut]
    [SwaggerOperation("Create or replace a residential property", "")]
    public IActionResult Put(int id) {
        return new OkResult();
    }


    [HttpPatch("id")]
    [SwaggerOperation("Update a residential property", "")]
    public IActionResult Patch(int id, JsonPatchDocument<ResidentialPropertyDto> residentialPropertyDto) {
        return new OkResult();
    }


    [HttpDelete("{id}")]
    [SwaggerOperation("Delete a residential property by Id", "")]
    public IActionResult Delete(int id) {
        return new OkResult();
    }

    #endregion


    #region Residential sales state

    //[HttpPost]
    //public IActionResult GetResidentialSalesState([FromBody] query) {

    //    return new OkResult();
    //}

    #endregion
}