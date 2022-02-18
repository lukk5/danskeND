using Newtonsoft.Json;

namespace danskeND.Repository.Entity.Common;

public abstract class BaseEntity
{
    [JsonIgnore]
    public Guid Id { get; set; }
}