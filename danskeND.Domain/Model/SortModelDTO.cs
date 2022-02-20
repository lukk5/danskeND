using danskeND.Domain.Model.Common;

namespace danskeND.Domain.Model;

public class SortModelDTO : BaseModelDTO
{
    public IEnumerable<long> Input { get; set; }
    public IEnumerable<long> SortedOutput { get; set; }
    public IEnumerable<MeasureResultDTO> MeasureResults { get; set; }
}