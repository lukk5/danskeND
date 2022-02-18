using danskeND.Repository.Entity.Common;

namespace danskeND.Repository.Entity;

public class SortEntity : AuditableEntity
{
    public IEnumerable<int> Input { get; set; }
    public IEnumerable<int> SortedOutput { get; set; }
    public IEnumerable<MeasureResultEntity> MeasureResults { get; set; }
}