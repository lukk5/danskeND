using System.Text.Json.Serialization;

namespace danskeND.Domain.Model.Common;
public abstract class BaseModelDTO
{
    [JsonIgnore]
    public string Id { get; set; }
}