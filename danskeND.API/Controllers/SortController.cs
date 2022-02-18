using danskeND.Domain.Model;
using danskeND.Domain.Model.Common;
using danskeND.Domain.Services.Interfaces;
using danskeND.Repository.Entity;
using danskeND.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace danskeND.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SortController : ControllerBase
{
    private readonly ISortingService _sortingService;

    public SortController(ISortingService sortingService)
    {
        _sortingService = sortingService;
    }

    [HttpPost]
    [Route("sort")]
    public async Task<IActionResult> Sort(SortingViewModel input)
    {
        var result = await _sortingService.SortCollectionAsync(new SortModelDTO
        {
            Input = input.Input
        });

        if (result.Success)
            return new OkObjectResult(result);

        return new BadRequestObjectResult(result);
    }

    [HttpGet]
    [Route("get/all")]
    public async Task<IActionResult> GetAllSortingData()
    {
        var result = await _sortingService.GetAllSortedDataAsync();
        if (result.Success)
            return new OkObjectResult(result);

        return new BadRequestObjectResult(result);
    }

    [HttpGet]
    [Route("get/last")]
    public async Task<IActionResult> GetLastSortingData()
    {
        var result = await _sortingService.GetLastSortedDataAsync();
        if (result.Success)
            return new OkObjectResult(result);

        return new BadRequestObjectResult(result);
    }

}