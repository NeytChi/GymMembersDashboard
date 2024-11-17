using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GymMembersDashboard.Windows;

namespace GymMembersDashboard
{
    /// <summary>
    /// Interaction logic for HistogramWindow.xaml
    /// </summary>
    public partial class HistogramWindow : Window, IChartWindow
    {
        // private PreparationMembers Preparation { get; set; }
        
        public HistogramWindow()
        {
            InitializeComponent();
        }   
        public void Setup(PreparationMembers preparation)
        {
            AgeChart.Series = preparation.GetAges();
            BMIChart.Series = preparation.GetBMIs();
            CaloriesChart.Series = preparation.GetCalories();
            SessionDurationChart.Series = preparation.GetSessionDurations();
        }
    }
}
