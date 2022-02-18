using danskeND.Domain.Model;
using danskeND.Domain.Model.Common;

namespace danskeND.Domain.Services.Interfaces;

public interface ISortingService
{
    Task<Result<SortModelDTO>> SortCollectionAsync(SortModelDTO input);
    Task<Result<SortModelDTO>> GetLastSortedDataAsync();
    Task<Result<SortModelDTO>> GetAllSortedDataAsync();
}