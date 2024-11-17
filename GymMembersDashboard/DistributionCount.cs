namespace GymMembersDashboard
{
    public class DistributionStringCount
    {
        public string Key { get; set; }
        public int Count { get; set; }
    }
    public class DistributionDoubleCount
    {
        public double Key { get; set; }
        public int Count { get; set; }
    }
    public class DistributionIntCount
    {
        public int Key { get; set; }
        public int Count { get; set; }
    }
    public class WeightCount
    {
        public double From { get; set; }
        public double To { get; set; }
        public int Count { get; set; }
    }
    public class SessionHours : WeightCount
    {

    }
}
