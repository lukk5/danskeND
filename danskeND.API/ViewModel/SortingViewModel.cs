using System.ComponentModel.DataAnnotations;

namespace danskeND.ViewModel;

public class SortingViewModel
{
    [Required]
    public List<long> Input { get; set; }
}