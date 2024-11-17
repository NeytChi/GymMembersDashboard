using System.Windows;
using GymMembersDashboard.Windows;
using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace GymMembersDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PreparationMembers preparation { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            SetUpCharts();
        }
        public void SetUpCharts()
        {
            var import = new ImportMembers();
            var members = import.GetMembers();
            var analyzer = new AnalyzerMembers(members);
            preparation = new PreparationMembers(analyzer);
            DGenders.Series = preparation.GetGenders();
            DWorkOut.Series = preparation.GetWorkOuts();
            DExperienceLevel.Series = preparation.GetExperienceLevel();
            DWeight.Series = preparation.GetWeights();
            DSessionDuration.Series = preparation.GetSessionDurations();
            DAges.Series = preparation.GetAges();
        }
        public void RunWindow(IChartWindow window)
        {
            window.Show();
            window.Setup(preparation);
        }
        private void ForHistograms_Click(object sender, RoutedEventArgs e)
        {
            RunWindow(new HistogramWindow());
        }
        private void ForScatterPlot_Click(object sender, RoutedEventArgs e)
        {
            RunWindow(new ScatterPlotWindow());
        }
        private void ForBoxPlots_Click(object sender, RoutedEventArgs e)
        {
            RunWindow(new BoxPlotWindow());
        }
    }
}