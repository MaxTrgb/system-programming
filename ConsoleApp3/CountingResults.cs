using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    [Serializable]
    public class CountingResults
    {
        public int maxNumber { get; set; }
        public int minNumber { get; set; }
        public double meanNumber { get; set; }
    }
}
