using danskeND.Repository.Entity.Common;

namespace danskeND.Repository.Entity;

public class SortEntity : AuditableEntity
{
    public IEnumerable<long> Input { get; set; }
    public IEnumerable<long> SortedOutput { get; set; }
    public IEnumerable<MeasureResultEntity> MeasureResults { get; set; }
}