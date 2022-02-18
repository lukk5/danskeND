
using danskeND.Domain.Model.Common;
namespace danskeND.Domain.Model;
public class MeasureResultDTO : BaseModelDTO
{
    public string Algorithm { get; set; }
    public TimeSpan Time { get; set; }
}