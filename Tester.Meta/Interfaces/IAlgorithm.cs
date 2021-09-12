using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Interfaces
{
    public interface IAlgorithm
    {
        public string Name { get; }
        public void TestRun(object[] @params = null);
    }
}
