using danskeND.Domain.Services.Interfaces;

namespace danskeND.Domain.Services;

public class SortingAlgorithm : ISortingAlgorithm
{
    public List<long> BubbleSorting(List<long> input)
    {
        long tempVariable = 0;
        var result = input;

        for (var j = 0; j < result.Count; j++)
        {
            for (var i = 0; i < result.Count - 1; i++)
            {
                if (result[i] <= result[i + 1]) continue;
                tempVariable = result[i + 1];
                result[i + 1] = result[i];
                result[i] = tempVariable;
            }
        }

        return result;
    }

    public List<long> SelectionSorting(List<long> input)
    {
        var result = input;

        for (var i = 0; i < result.Count; i++)
        {
            var min = i;
            for (var j = i + 1; j < result.Count; j++)
                if (result[min] > result[j])
                    min = j;

            if (min == i) continue;
            (result[min], result[i]) = (result[i], result[min]);
        }

        return result;
    }

    public List<long> InsertionSorting(List<long> input)
    {
        var result = input;

        for (var i = 0; i < result.Count; i++)
        {
            var item = input[i];
            var currentIndex = i;

            while (currentIndex > 0 && result[currentIndex - 1] > item)
            {
                result[currentIndex] = result[currentIndex - 1];
                currentIndex--;
            }

            result[currentIndex] = item;
        }

        return result;
    }
}