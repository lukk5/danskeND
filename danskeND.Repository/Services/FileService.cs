using danskeND.Repository.Services.Interfaces;
using Newtonsoft.Json;

namespace danskeND.Repository.Services;

public class FileService<T> : IFileService<T> where T : class
{
    private static readonly string filePath = Directory.GetCurrentDirectory() + "/data/data.json"; 

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
            // Ignore this. 
        }

        if (existingData is not null)
            newData.AddRange(existingData.ToList()); 
        
        var json = JsonConvert.SerializeObject(newData);

        await File.WriteAllTextAsync(filePath, json);
    }
    
    
}