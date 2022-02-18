
using danskeND.Repository.Entity.Common;
using danskeND.Repository.Enum;

namespace danskeND.Repository.Entity;

public class MeasureResultEntity : AuditableEntity
{
    public SortingAlgorithm Algorithm { get; set; }
    public TimeSpan Time { get; set; }
}