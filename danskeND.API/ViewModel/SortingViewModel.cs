using System.ComponentModel.DataAnnotations;

namespace danskeND.ViewModel;

public class SortingViewModel
{
    [Required]
    public List<int> Input { get; set; }
}