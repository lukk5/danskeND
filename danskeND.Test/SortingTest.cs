using System.Collections.Generic;
using danskeND.Domain.Services;
using danskeND.Domain.Services.Interfaces;
using NUnit.Framework;

namespace danskeND.Test;

public class Tests
{
    private ISortingAlgorithm _sortingAlgorithm;

    [SetUp]
    public void Setup()
    {
        _sortingAlgorithm = new SortingAlgorithm();
    }

    [Test, TestCaseSource(typeof(SortingAlgorithmTestCases))]
    public void BubleSorting(List<long> input, List<long> expectedResult)
    {
        var result = _sortingAlgorithm.BubbleSorting(input);
        Assert.AreEqual(expectedResult, result);
    }

    [Test, TestCaseSource(typeof(SortingAlgorithmTestCases))]
    public void SelectionSorting(List<long> input, List<long> expectedResult)
    {
        var result = _sortingAlgorithm.SelectionSorting(input);
        Assert.AreEqual(expectedResult, result);
    }

    [Test, TestCaseSource(typeof(SortingAlgorithmTestCases))]
    public void InsertionSorting(List<long> input, List<long> expectedResult)
    {
        var result = _sortingAlgorithm.InsertionSorting(input);
        Assert.AreEqual(expectedResult, result);
    }
}