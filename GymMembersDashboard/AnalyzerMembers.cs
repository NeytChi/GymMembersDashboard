namespace GymMembersDashboard
{
    /// <summary>
    /// Інсайти з аналізу даних MemberTracks з таблиці.
    /// </summary>
    internal class AnalyzerMembers
    {
        public ICollection<MemberTrack> Members { get; set; }
        public AnalyzerMembers(ICollection<MemberTrack> members)
        {
            Members = members;
        }
        /// <summary>
        /// 1. Розподіл між жінками і чоловіками - ключ і кількість.
        /// </summary>
        /// <returns>Ліст з двома об'єктами, котрі маю ключ "Men/Women" і кількістю записів по кожній.</returns>
        public IEnumerable<DistributionStringCount> GetGenderDistribution()
        {
            return new List<DistributionStringCount>()
            {
                new DistributionStringCount {Key = "Women", Count = Members.Where(m => m.Gender == false).Count()},
                new DistributionStringCount {Key = "Men", Count = Members.Where(m => m.Gender == true).Count()}
            };
        }
        /// <summary>
        /// 2. Кількісний розподіл між типом тренуванням.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DistributionStringCount> GetWorkOutTypeDistribution()
        {
            return Members.GroupBy(g => g.WorkoutType).Select(s =>
                new DistributionStringCount
                {
                    Key = s.Key,
                    Count = s.Count()
                }
            ).ToArray();
        }
        /// <summary>
        /// 3. Кількісний розподіл між частотою тренуванням.
        /// </summary>
        /// <returns>
        /// Ключ - це кількість тренування в неділю
        /// Значення - кількість людей, котрі займаються відповідним режимом
        /// </returns>
        public IEnumerable<DistributionIntCount> GetWorkOutFrequenciesDistribution()
        {
            return Members.GroupBy(g => g.WorkoutFrequency).Select(s =>
                new DistributionIntCount
                {
                    Key = s.Key,
                    Count = s.Count()
                }
            ).ToArray();
        }
        /// <summary>
        /// Розподіл даних по рівню досвіду людей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DistributionIntCount> GetExpLevelDistribution()
        {
            return Members.GroupBy(g => g.ExperienceLevel).Select(s =>
                new DistributionIntCount
                {
                    Key = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
        /// Weight (kg) Distribution
        public IEnumerable<WeightCount> GetWeightDistribution()
        {
            return Members.GroupBy(g => ((int)g.Weight / 10) * 10).Select(s =>
                new WeightCount
                {
                    From = s.Key - 10,
                    To = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
        /// Session_Duration (hours) Distribution
        public IEnumerable<SessionHours> GetSessionHours()
        {
            return Members.GroupBy(g => ((int)(g.SessionDuration * 100) / 10) / 10).Select(s =>
                new SessionHours
                {
                    From = s.Key - 10,
                    To = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
        /// Calories_Burned Distribution
        public IEnumerable<WeightCount> GetCaloriesBurned()
        {
            return Members.GroupBy(g => (int)g.CaloriesBurned / 100 * 100).Select(s =>
                new WeightCount
                {
                    From = s.Key - 100,
                    To = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
        /// Age Distribution
        public IEnumerable<DistributionDoubleCount> GetAges()
        {
            return Members.GroupBy(g => g.Age).Select(s =>
                new DistributionDoubleCount
                {
                    Key = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
        /// Height (m) Distribution
        public IEnumerable<WeightCount> GetHeights()
        {
            return Members.GroupBy(g => ((int)g.Height / 10) * 10)
                .Select(s => new WeightCount
                {
                    From = s.Key - 10,
                    To = s.Key,
                    Count = s.Count()
                }
                ).ToArray();
        }
        /// Max_BPM Distribution
        public IEnumerable<WeightCount> GetMaxBPM()
        {
            return Members.GroupBy(g => (g.MaxBPM / 10) * 10)
                .Select(s => new WeightCount
                {
                    From = s.Key - 10,
                    To = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
        public IEnumerable<WeightCount> GetAvgBPM()
        {
            return Members.GroupBy(g => (g.AvgBPM / 10) * 10)
                .Select(s => new WeightCount
                {
                    From = s.Key - 10,
                    To = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
        /// Resting_BPM Distribution
        public IEnumerable<WeightCount> GetRestingBPM()
        {
            return Members.GroupBy(g => (g.RestingBPM / 10) * 10)
                .Select(s => new WeightCount
                {
                    From = s.Key - 10,
                    To = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
        /// Fat_Percentage Distribution
        public IEnumerable<WeightCount> GetFatPercentage()
        {
            return Members.GroupBy(g => (g.FatPercentage / 10) * 10)
                .Select(s => new WeightCount
                {
                    From = s.Key - 10,
                    To = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
        /// Water_Intake (liters) Distribution
        public IEnumerable<WeightCount> GetWaterIntakeLiters()
        {
            return Members.GroupBy(g => (((int)g.WaterIntake) / 10) * 10)
                .Select(s => new WeightCount
                {
                    From = s.Key - 10,
                    To = s.Key,
                    Count = s.Count()
                }).ToArray();
        }
    }
}