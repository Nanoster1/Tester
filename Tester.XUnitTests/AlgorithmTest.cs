using System;
using System.Collections.Generic;
using System.Reflection;
using Tester.Meta.Algorithms.FirstTask;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;
using Xunit;

namespace Tester.XUnitTests
{
    public class AlgorithmTest
    {
        [Theory]
        [MemberData(nameof(AlgorithmData))]
        public void AlgorithmsTest(IAlgorithm algorithm) 
        { 
            var tester = new TimeTester();
            tester.Test(algorithm);
        }
        public static IEnumerable<object[]> AlgorithmData()
        {
            yield return new object[] {new FirstAlgorithm()};
            yield return new object[] {new SecondAlgorithm()};
            yield return new object[] {new ThirdAlgorithm()};
        }
    }
}
