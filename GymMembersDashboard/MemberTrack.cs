namespace GymMembersDashboard
{
    public class MemberTrack
    {
        [ExcelColumn("Age")]
        public double Age { get; set; }
        [ExcelColumn("Gender")]
        public bool Gender { get; set; }
        [ExcelColumn("Weight (kg)")]
        public double Weight { get; set; }
        [ExcelColumn("Height (m)")]
        public double Height { get; set; }
        [ExcelColumn("Max_BPM")]
        public int MaxBPM { get; set; }
        [ExcelColumn("Avg_BPM")]
        public int AvgBPM { get; set; }
        [ExcelColumn("Resting_BPM")]
        public int RestingBPM { get; set; }
        [ExcelColumn("Session_Duration (hours)")]
        public double SessionDuration { get; set; }
        [ExcelColumn("Calories_Burned")]
        public double CaloriesBurned { get; set; }
        [ExcelColumn("Workout_Type")]
        public string WorkoutType { get; set; }
        [ExcelColumn("Fat_Percentage")]
        public double FatPercentage { get; set; }
        [ExcelColumn("Water_Intake (liters)")]
        public double WaterIntake { get; set; }
        [ExcelColumn("Workout_Frequency (days/week)")]
        public int WorkoutFrequency { get; set; }
        [ExcelColumn("Experience_Level")]
        public int ExperienceLevel { get; set; }
        [ExcelColumn("BMI")]
        public double BMI { get; set; }
    }
}
