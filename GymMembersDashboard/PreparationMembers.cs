using LiveCharts;
using LiveCharts.Wpf;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Drawing;
using System.Windows.Media;

namespace GymMembersDashboard
{
    public class PreparationMembers
    {
        public AnalyzerMembers AnalyzerMembers { get; set; }
        public PreparationMembers(AnalyzerMembers analyzerMembers)
        {
            AnalyzerMembers = analyzerMembers;
        }
        public SeriesCollection GetAges()
        {
            var ages = AnalyzerMembers.GetAges();

            var chartAges = new SeriesCollection();

            foreach (var age in ages)
            {
                chartAges.Add(new ColumnSeries
                {
                    Title = age.Key.ToString(),
                    Values = new ChartValues<int> { age.Count }
                });
            }
            return chartAges;
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
                    new ColumnSeries
                    {
                        Title = workOut.Key.ToString() + " -",
                        Values = new ChartValues<int> { workOut.Count }
                    }
                    );
            }
            return seriesWorkOut;
        }
        public SeriesCollection GetExperienceLevel()
        {
            var expLevels = AnalyzerMembers.GetExpLevelDistribution();
            var seriesExperienceLevel = new SeriesCollection();

            foreach(var expLevel in expLevels)
            {
                seriesExperienceLevel.Add(GetColumnKeyValue(expLevel));
            }
            return seriesExperienceLevel;
        }
        public SeriesCollection GetWeights()
        {
            var weights = AnalyzerMembers.GetWeightDistribution();
            var seriesWeights = new SeriesCollection();

            foreach (var weight in weights)
            {
                seriesWeights.Add(GetColumnFromToCount(weight));
            }
            return seriesWeights;
        }
        public SeriesCollection GetSessionDurations()
        {
            var sessionDurations = AnalyzerMembers.GetSessionHours();
            var seriesSessions = new SeriesCollection();

            foreach (var session in sessionDurations)
            {
                seriesSessions.Add(GetColumnFromToCount(session));
            }
            return seriesSessions;
        }
        public SeriesCollection GetCalories()
        {
            var calories = AnalyzerMembers.GetCaloriesBurned();
            var seriesCalories = new SeriesCollection();

            foreach (var calory in calories)
            {
                seriesCalories.Add(GetColumnFromToCount(calory));
            }
            return seriesCalories;
        }
        public SeriesCollection GetBMIs()
        {
            var bmis = AnalyzerMembers.GetBMIs();
            var seriesBMIs = new SeriesCollection();

            foreach (var bmi in bmis)
            {
                seriesBMIs.Add(GetColumnKeyValue(bmi));
            }
            return seriesBMIs;
        }
        public ColumnSeries GetColumnKeyValue(DistributionDoubleCount d)
        {
            return new ColumnSeries
            {
                Title = d.Key.ToString() + " -",
                Values = new ChartValues<int> { d.Count }
            };
        }
        public ColumnSeries GetColumnKeyValue(DistributionIntCount d)
        {
            return new ColumnSeries
            {
                Title = d.Key.ToString() + " -",
                Values = new ChartValues<int> { d.Count }
            };
        }
        public ColumnSeries GetColumnFromToCount(WeightCount d)
        {
            return new ColumnSeries
            {
                Title = d.From.ToString() + "-" + d.To.ToString(),
                Values = new ChartValues<int> { d.Count }
            };
        }
    }
}
