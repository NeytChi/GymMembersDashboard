using System.Windows;
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
            var preparation = new PreparationMembers(analyzer);
            DGenders.Series = preparation.GetGenders();
            DWorkOut.Series = preparation.GetWorkOuts();
        }
    }
}