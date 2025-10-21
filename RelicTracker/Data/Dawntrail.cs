using static RelicTracker.Data.General;

namespace RelicTracker.Data
{
    public class Dawntrail
    {
        public class Penumbrae : IRelicPhase
        {
            public string Name { get; set; } = "Penumbrae";
            public IRelicPhaseData Data { get; set; } = new();

            public Penumbrae()
            {
                Data.ExchangeItemId = 47750;
                Data.ExchangeItemMultiplier = 3;

                Data.ClassAchievementMap.Add(Job.Paladin, 3638);
                Data.ClassAchievementMap.Add(Job.Monk, 3643);
                Data.ClassAchievementMap.Add(Job.Warrior, 3639);
                Data.ClassAchievementMap.Add(Job.Dragoon, 3642);
                Data.ClassAchievementMap.Add(Job.Bard, 3648);
                Data.ClassAchievementMap.Add(Job.WhiteMage, 3655);
                Data.ClassAchievementMap.Add(Job.BlackMage, 3651);
                Data.ClassAchievementMap.Add(Job.Summoner, 3652);
                Data.ClassAchievementMap.Add(Job.Scholar, 3656);
                Data.ClassAchievementMap.Add(Job.Ninja, 3644);
                Data.ClassAchievementMap.Add(Job.Machinist, 3649);
                Data.ClassAchievementMap.Add(Job.DarkKnight, 3640);
                Data.ClassAchievementMap.Add(Job.Astrologian, 3657);
                Data.ClassAchievementMap.Add(Job.Samurai, 3646);
                Data.ClassAchievementMap.Add(Job.RedMage, 3653);
                Data.ClassAchievementMap.Add(Job.Gunbreaker, 3641);
                Data.ClassAchievementMap.Add(Job.Dancer, 3650);
                Data.ClassAchievementMap.Add(Job.Reaper, 3647);
                Data.ClassAchievementMap.Add(Job.Sage, 3658);
                Data.ClassAchievementMap.Add(Job.Viper, 3645);
                Data.ClassAchievementMap.Add(Job.Pictomancer, 3654);
            }
        }

        public class Umbrae : IRelicPhase
        {
            public string Name { get; set; } = "Umbrae";
            public IRelicPhaseData Data { get; set; } = new();

            public Umbrae()
            {
                Data.ExchangeItemId = 46850;
                Data.ExchangeItemMultiplier = 3;

                Data.ClassAchievementMap.Add(Job.Paladin, 3752);
                Data.ClassAchievementMap.Add(Job.Monk, 3757);
                Data.ClassAchievementMap.Add(Job.Warrior, 3753);
                Data.ClassAchievementMap.Add(Job.Dragoon, 3756);
                Data.ClassAchievementMap.Add(Job.Bard, 3762);
                Data.ClassAchievementMap.Add(Job.WhiteMage, 3769);
                Data.ClassAchievementMap.Add(Job.BlackMage, 3765);
                Data.ClassAchievementMap.Add(Job.Summoner, 3766);
                Data.ClassAchievementMap.Add(Job.Scholar, 3770);
                Data.ClassAchievementMap.Add(Job.Ninja, 3758);
                Data.ClassAchievementMap.Add(Job.Machinist, 3763);
                Data.ClassAchievementMap.Add(Job.DarkKnight, 3754);
                Data.ClassAchievementMap.Add(Job.Astrologian, 3771);
                Data.ClassAchievementMap.Add(Job.Samurai, 3760);
                Data.ClassAchievementMap.Add(Job.RedMage, 3767);
                Data.ClassAchievementMap.Add(Job.Gunbreaker, 3755);
                Data.ClassAchievementMap.Add(Job.Dancer, 3764);
                Data.ClassAchievementMap.Add(Job.Reaper, 3761);
                Data.ClassAchievementMap.Add(Job.Sage, 3772);
                Data.ClassAchievementMap.Add(Job.Viper, 3759);
                Data.ClassAchievementMap.Add(Job.Pictomancer, 3768);
            }
        }
    }
}
