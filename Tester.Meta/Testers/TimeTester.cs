using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Meta.Interfaces;

namespace Tester.Meta.Testers
{
    public class TimeTester : Tester<TimeSpan>
    {
        public override TimeSpan Result { get; protected set; }

        public override void Test(IAlgorithm algorithm)
        {
            var time = Stopwatch.StartNew();
            time.Start();
            algorithm.TestRun();
            time.Stop();
            Result = time.Elapsed;
        }
    }
}
