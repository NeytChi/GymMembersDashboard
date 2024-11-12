using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembersDashboard
{
    internal class DistributionStringCount
    {
        public string Key { get; set; }
        public int Count { get; set; }
    }
    internal class DistributionDoubleCount
    {
        public double Key { get; set; }
        public int Count { get; set; }
    }
    internal class DistributionIntCount
    {
        public int Key { get; set; }
        public int Count { get; set; }
    }
    internal class WeightCount
    {
        public double From { get; set; }
        public double To { get; set; }
        public int Count { get; set; }
    }
    internal class SessionHours : WeightCount
    {

    }
}
