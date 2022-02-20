using System.Diagnostics;
using System.Net;
using AutoMapper;
using danskeND.Domain.Model;
using danskeND.Domain.Model.Common;
using danskeND.Domain.Services.Interfaces;
using danskeND.Repository.Entity;
using danskeND.Repository.Entity.Common;
using danskeND.Repository.Enum;
using danskeND.Repository.Repositories.Common;
using danskeND.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace danskeND.Domain.Services;

public class SortingService : ISortingService
{
    private readonly BaseRepository<SortEntity> _baseRepository;
    private readonly IFileService<SortEntity> _fileService;
    private readonly IMapper _mapper;
    private readonly ISortingAlgorithm _sortingAlgorithm;
    private readonly ILogger _logger;

    /*public SortingService(IBaseRepository baseRepository, IMapper mapper) // jei naudociau db
    {
        _baseRepository = baseRepository;
        _mapper = mapper;
    }*/


    public SortingService(IFileService<SortEntity> fileService, IMapper mapper, ISortingAlgorithm sortingAlgorithm, ILogger<SortingService> logger)
    {
        _mapper = mapper;
        _fileService = fileService;
        _sortingAlgorithm = sortingAlgorithm;
        _logger = logger;
    }

    public async Task<Result<SortModelDTO>> SortCollectionAsync(SortModelDTO input)
    {
        if (!input.Input.Any())
            return new Result<SortModelDTO>(new List<SortModelDTO>() { input }, false, new HttpRequestException(
                "Input is empty.", new ArgumentNullException(),
                HttpStatusCode.BadRequest));

        var sortedList = _sortingAlgorithm.BubbleSorting(input.Input.ToList());

        var sortedEntity = _mapper.Map<SortEntity>(input);

        MeasureSorting(sortedEntity);

        sortedEntity.SortedOutput = sortedList;

        try
        {
            /*var createdEntity = await WriteDataToDb(sortedEntity);
            return new Result<SortModelDTO>(new List<SortModelDTO>
                { _mapper.Map<SortModelDTO>(createdEntity) }, true); // listas del universalumo*/

            await WriteDataToFile(sortedEntity);
            
            return new Result<SortModelDTO>(new List<SortModelDTO>
                { _mapper.Map<SortModelDTO>(sortedEntity) }, true);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new Result<SortModelDTO>(new List<SortModelDTO>
                { _mapper.Map<SortModelDTO>(sortedEntity) }, false, e);
        }
    }

    public async Task<Result<SortModelDTO>> GetLastSortedDataAsync()
    {
        try
        {
            var result = await _fileService.ReadJsonFromFileAsync();

            if (result is null)
                return new Result<SortModelDTO>(null, true, null, "No data.");

            var lastSortedEntity = result.OrderByDescending(x => x.CreatedAt).FirstOrDefault();

            return new Result<SortModelDTO>(new List<SortModelDTO> { _mapper.Map<SortModelDTO>(lastSortedEntity) },
                true);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new Result<SortModelDTO>(null, false, e);
        }
    }

    private void SetupEntityForFile(AuditableEntity entity)
    {
        entity.CreatedAt = DateTime.Now;
        entity.CreatedBy = "system";
        entity.LastUpdatedAt = DateTime.Now;
        entity.LastUpdatedBy = "system";
    }

    public async Task<Result<SortModelDTO>> GetAllSortedDataAsync()
    {
        try
        {
            var result = await _fileService.ReadJsonFromFileAsync();
            return new Result<SortModelDTO>(_mapper.Map<IEnumerable<SortModelDTO>>(result), true);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new Result<SortModelDTO>(null, false, e);
        }
    }

    private async Task<SortEntity?> WriteDataToDb(SortEntity input)
    {
        var newEntityId = new Guid();
        input.Id = newEntityId;
        await _baseRepository.AddAsync(input);
        return await _baseRepository.GetByIdAsync(newEntityId);
    }

    private async Task WriteDataToFile(SortEntity input)
    {
        SetupEntityForFile(input); // cia tik failo atvejui, jei rasyciau i db tai esu dbcontext overridines SaveChangesAsync metoda ir ten situs property settinciau. 
        await _fileService.WriteJsonToFileAsync(new List<SortEntity> { input });
    }


    private void MeasureSorting(SortEntity input)
    {
        var stopWatch = new Stopwatch();

        var testSubjectOne = input.Input.ToList();
        var testSubjectTwo = input.Input.ToList();
        var testSubjectThree = input.Input.ToList();

        stopWatch.Start();
        _sortingAlgorithm.BubbleSorting(testSubjectOne);
        stopWatch.Stop();

        var firstTime = stopWatch.Elapsed;
        stopWatch.Reset();

        stopWatch.Start();
        _sortingAlgorithm.SelectionSorting(testSubjectTwo);
        stopWatch.Stop();

        var secondTime = stopWatch.Elapsed;
        stopWatch.Reset();

        stopWatch.Start();
        _sortingAlgorithm.InsertionSorting(testSubjectThree);
        stopWatch.Stop();

        var thirdTime = stopWatch.Elapsed;
        stopWatch.Reset();

        input.MeasureResults = new List<MeasureResultEntity>
        {
            new()
            {
                AlgorithmType = SortingAlgorithmType.Bubble,
                Time = firstTime,
                Id = Guid.NewGuid()
            },
            new()
            {
                AlgorithmType = SortingAlgorithmType.Selection,
                Time = secondTime,
                Id = Guid.NewGuid()
            },
            new()
            {
                AlgorithmType = SortingAlgorithmType.Insertion,
                Time = thirdTime,
                Id = Guid.NewGuid()
            },
        };
    }
}