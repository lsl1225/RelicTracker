using Lumina.Excel.Sheets;

namespace RelicTracker.Data
{
    public static class Job
    {
        public static int Paladin { get; } = 19;
        public static int Monk { get; } = 20;
        public static int Warrior { get; } = 21;
        public static int Dragoon { get; } = 22;
        public static int Bard { get; } = 23;
        public static int WhiteMage { get; } = 24;
        public static int BlackMage { get; } = 25;
        public static int Summoner { get; } = 27;
        public static int Scholar { get; } = 28;
        public static int Ninja { get; } = 30;
        public static int Machinist { get; } = 31;
        public static int DarkKnight { get; } = 32;
        public static int Astrologian { get; } = 33;
        public static int Samurai { get; } = 34;
        public static int RedMage { get; } = 35;
        public static int Gunbreaker { get; } = 37;
        public static int Dancer { get; } = 38;
        public static int Reaper { get; } = 39;
        public static int Sage { get; } = 40;
        public static int Viper { get; } = 41;
        public static int Pictomancer { get; } = 42;

        public static ClassJob? GetJob(int job)
        {
            var classJobs = Service.LuminaSheet<ClassJob>();
            if (classJobs != null)
                return classJobs.GetRow((uint)job);

            return null;
        }
    }
}
