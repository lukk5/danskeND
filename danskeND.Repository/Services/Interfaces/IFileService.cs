namespace danskeND.Repository.Services.Interfaces;

public interface IFileService<T> where T : class
{
    Task<IEnumerable<T>?> ReadJsonFromFileAsync();
    Task WriteJsonToFileAsync(IEnumerable<T> input);
}