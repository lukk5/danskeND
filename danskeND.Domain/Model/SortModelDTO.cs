using danskeND.Domain.Model.Common;

namespace danskeND.Domain.Model;

public class SortModelDTO : BaseModelDTO
{
    public IEnumerable<int> Input { get; set; }
    public IEnumerable<int> SortedOutput { get; set; }
    public IEnumerable<MeasureResultDTO> Results { get; set; }
}