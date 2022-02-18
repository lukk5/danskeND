using Newtonsoft.Json;

namespace danskeND.Repository.Entity.Common;

public abstract class AuditableEntity : BaseEntity
{
    [JsonIgnore]
    public string? CreatedBy { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }
    [JsonIgnore]
    public string? LastUpdatedBy { get; set; }
    [JsonIgnore]
    public DateTime LastUpdatedAt { get; set; }
}