using Das.Application.ResidentialProperties;
using Das.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Das.WebApi.Controllers;

[SwaggerTag("Create, read, update, delete Residential Property and Calculate sales state")]
public class ResidentialPropertyController : VersionedApiController {
    private readonly IResidentialPropertyService _residentialPropertyService;

    public ResidentialPropertyController(IResidentialPropertyService residentialPropertyService) {
        _residentialPropertyService = residentialPropertyService;
    }


    [HttpPost("SaleStats")]
    [SwaggerOperation("Get residential property sale statistics", "")]
    public async Task<IReadOnlyList<ResidentialSaleState>> GetSalesStateAsync(
        ResidentialPropertySearchCriteria searchCriteria) {
        return await _residentialPropertyService.GetSaleStateAsync(searchCriteria);
    }


    [HttpGet("{id}")]
    [SwaggerOperation("Get a residential property by Id", "")]
    public async Task<ActionResult<ResidentialPropertyDto>> GetByIdAsync(int id) {
        return await _residentialPropertyService.FindByIdAsync(id);
    }


    [HttpPost("Find")]
    [SwaggerOperation("Find residential properties", "")]
    public async Task<IReadOnlyList<ResidentialPropertyDto>> FindAsync(ResidentialPropertySearchCriteria searchCriteria) {
        return await _residentialPropertyService.FindAsync(searchCriteria);
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

}