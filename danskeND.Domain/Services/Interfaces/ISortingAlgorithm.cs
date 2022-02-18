namespace danskeND.Domain.Services.Interfaces;

public interface ISortingAlgorithm
{
    List<int> BubbleSorting(List<int> input);
    List<int> SelectionSorting(List<int> input);
    List<int> InsertionSorting(List<int> input);
}