using System.Text.Json.Serialization;

namespace danskeND.Domain.Model.Common;
public class BaseModelDTO
{
    [JsonIgnore]
    public string Id { get; set; }
}