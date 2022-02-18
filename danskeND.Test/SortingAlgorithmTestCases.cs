using System.Collections;
using System.Collections.Generic;

namespace danskeND.Test;

public class SortingAlgorithmTestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { new List<long> {5,4,12,53,65,54,231,312}, new List<long> {4,5,12,53,54,65,231,312} };
        yield return new object[] { new List<long> {5,45,432,53,62,554,231,332}, new List<long> {5,45,53,62,231,332,432,554} };
        yield return new object[] { new List<long> {2,4,42,52,123,54,12312,23}, new List<long> {2,4,23,42,52,54,123,12312} };
    }
}