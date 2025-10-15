using Lumina.Excel.Sheets;
using Lumina.Extensions;
using System.Collections.Generic;
using System.Linq;
using static RelicTracker.Data.General;

namespace RelicTracker.Data
{
    public class Dawntrail
    {
        public IRelicData Penumbrae;
        public IRelicData Umbrae;

        public Dawntrail()
        {
            Penumbrae = new IRelicData();
            Penumbrae.ExchangeItem = Service.LuminaSheet<Item>()?.Where(row => row.RowId == 47750).FirstOrNull() ?? null;
            Penumbrae.ExchangeItemMultiplier = 3;

            Umbrae = new IRelicData();
            Umbrae.ExchangeItem = Service.LuminaSheet<Item>()?.Where(row => row.RowId == 46850).FirstOrNull() ?? null;
            Umbrae.ExchangeItemMultiplier = 3;

            var classJobs = Service.LuminaSheet<ClassJob>();
            var achievements = Service.LuminaSheet<Achievement>();

            if (classJobs == null || achievements == null)
            {
                Service.Log.Error("Data initialize error.");
                return;
            }

            Penumbrae.ClassAchievementMap = new Dictionary<ClassJob, Achievement>()
            {
                // paladin
                { classJobs.GetRow(19), achievements.GetRow(3752 - 114) },
                // monk
                { classJobs.GetRow(20), achievements.GetRow(3757 - 114) },
                // warrior
                { classJobs.GetRow(21), achievements.GetRow(3753 - 114) },
                // dragoon
                { classJobs.GetRow(22), achievements.GetRow(3756 - 114) },
                // bard
                { classJobs.GetRow(23), achievements.GetRow(3762 - 114) },
                // white mage
                { classJobs.GetRow(24), achievements.GetRow(3769 - 114) },
                // black mage
                { classJobs.GetRow(25), achievements.GetRow(3765 - 114) },
                // summoner
                { classJobs.GetRow(27), achievements.GetRow(3766 - 114) },
                // scholar
                { classJobs.GetRow(28), achievements.GetRow(3770 - 114) },
                // ninja
                { classJobs.GetRow(30), achievements.GetRow(3758 - 114) },
                // machinist
                { classJobs.GetRow(31), achievements.GetRow(3763 - 114) },
                // dark knight
                { classJobs.GetRow(32), achievements.GetRow(3754 - 114) },
                // astrologian
                { classJobs.GetRow(33), achievements.GetRow(3771 - 114) },
                // samurai
                { classJobs.GetRow(34), achievements.GetRow(3760 - 114) },
                // red mage
                { classJobs.GetRow(35), achievements.GetRow(3767 - 114) },
                // gunbreaker
                { classJobs.GetRow(37), achievements.GetRow(3755 - 114) },
                // dancer
                { classJobs.GetRow(38), achievements.GetRow(3764 - 114) },
                // reaper
                { classJobs.GetRow(39), achievements.GetRow(3761 - 114) },
                // sage
                { classJobs.GetRow(40), achievements.GetRow(3772 - 114) },
                // viper
                { classJobs.GetRow(41), achievements.GetRow(3759 - 114) },
                // pictomancer
                { classJobs.GetRow(42), achievements.GetRow(3768 - 114) },
            };

            Umbrae.ClassAchievementMap = new Dictionary<ClassJob, Achievement>()
            {
                // paladin
                { classJobs.GetRow(19), achievements.GetRow(3752) },
                // monk
                { classJobs.GetRow(20), achievements.GetRow(3757) },
                // warrior
                { classJobs.GetRow(21), achievements.GetRow(3753) },
                // dragoon
                { classJobs.GetRow(22), achievements.GetRow(3756) },
                // bard
                { classJobs.GetRow(23), achievements.GetRow(3762) },
                // white mage
                { classJobs.GetRow(24), achievements.GetRow(3769) },
                // black mage
                { classJobs.GetRow(25), achievements.GetRow(3765) },
                // summoner
                { classJobs.GetRow(27), achievements.GetRow(3766) },
                // scholar
                { classJobs.GetRow(28), achievements.GetRow(3770) },
                // ninja
                { classJobs.GetRow(30), achievements.GetRow(3758) },
                // machinist
                { classJobs.GetRow(31), achievements.GetRow(3763) },
                // dark knight
                { classJobs.GetRow(32), achievements.GetRow(3754) },
                // astrologian
                { classJobs.GetRow(33), achievements.GetRow(3771) },
                // samurai
                { classJobs.GetRow(34), achievements.GetRow(3760) },
                // red mage
                { classJobs.GetRow(35), achievements.GetRow(3767) },
                // gunbreaker
                { classJobs.GetRow(37), achievements.GetRow(3755) },
                // dancer
                { classJobs.GetRow(38), achievements.GetRow(3764) },
                // reaper
                { classJobs.GetRow(39), achievements.GetRow(3761) },
                // sage
                { classJobs.GetRow(40), achievements.GetRow(3772) },
                // viper
                { classJobs.GetRow(41), achievements.GetRow(3759) },
                // pictomancer
                { classJobs.GetRow(42), achievements.GetRow(3768) },
            };
        }
    }
}
