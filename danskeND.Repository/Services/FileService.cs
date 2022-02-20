using danskeND.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace danskeND.Repository.Services;

public class FileService<T> : IFileService<T> where T : class
{
    private static readonly string filePath = Directory.GetCurrentDirectory() + "/data/data.json";
    private readonly ILogger _logger;
    
    public FileService(ILogger<FileService<T>> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<T>?> ReadJsonFromFileAsync()
    {
        using var reader = new StreamReader(filePath);
        var json = await reader.ReadToEndAsync();
        return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
    }

    public async Task WriteJsonToFileAsync(IEnumerable<T> input)
    {
        IEnumerable<T>? existingData = null;
        var newData = input.ToList();

        try
        {
            existingData = await ReadJsonFromFileAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            _logger.LogInformation("File is empty");
            // Ignore this, because it means that file is empty. 
        }

        if (existingData is not null)
            newData.AddRange(existingData.ToList()); 
        
        var json = JsonConvert.SerializeObject(newData);

        await File.WriteAllTextAsync(filePath, json);
    }
    
    
}