using LiveCharts;
using LiveCharts.Wpf;

namespace GymMembersDashboard
{
    internal class PreparationMembers
    {
        public AnalyzerMembers AnalyzerMembers { get; set; }
        public PreparationMembers(AnalyzerMembers analyzerMembers)
        {
            AnalyzerMembers = analyzerMembers;
        }
        public SeriesCollection GetGenders()
        {
            var genders = AnalyzerMembers.GetGenderDistribution();

            var pieGenders = new SeriesCollection();

            foreach (var gender in genders)
            {
                pieGenders.Add(
                    new PieSeries 
                    { 
                        Title = gender.Key, 
                        Values = new ChartValues<int> { gender.Count } 
                    }
                );
            }
            return pieGenders;
        }
        public SeriesCollection GetWorkOuts()
        {
            var workOuts = AnalyzerMembers.GetWorkOutFrequenciesDistribution();
            var seriesWorkOut = new SeriesCollection();

            foreach (var workOut in workOuts)
            {
                seriesWorkOut.Add(
                    new LineSeries
                    {
                        Title = workOut.Key.ToString(),
                        Values = new ChartValues<int> { workOut.Count }
                    }
                    );
            }
            return seriesWorkOut;
        }
    }
}
