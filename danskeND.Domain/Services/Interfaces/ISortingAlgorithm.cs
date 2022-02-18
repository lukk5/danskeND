namespace danskeND.Domain.Services.Interfaces;

public interface ISortingAlgorithm
{
    List<long> BubbleSorting(List<long> input);
    List<long> SelectionSorting(List<long> input);
    List<long> InsertionSorting(List<long> input);
}