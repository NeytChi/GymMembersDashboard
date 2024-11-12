using LiveCharts;

namespace GymMembersDashboard
{
    internal class PreparationMembers
    {
        public AnalyzerMembers AnalyzerMembers { get; set; }
        public PreparationMembers(AnalyzerMembers  analyzerMembers) 
        {
            AnalyzerMembers = analyzerMembers;
        }
        public SeriesCollection GetGenders()
        {
            var genders = AnalyzerMembers.GetGenderDistribution();

            
            return new SeriesCollection(genders);
        }
    }
}
