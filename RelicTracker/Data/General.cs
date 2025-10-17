using Lumina.Excel.Sheets;
using Lumina.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace RelicTracker.Data
{
    public class General
    {
        public interface IRelicPhase
        {
            string Name { get; }
            IRelicPhaseData Data { get; }
        }

        public class IRelicPhaseData
        {
            public int? ExchangeItemId { get; set; } = null;

            public int ExchangeItemMultiplier { get; set; } = 0;

            public Dictionary<int, int> ClassAchievementMap { get; set; } = new();

            public Item? GetExchangeItem()
            {
                return Service.LuminaSheet<Item>()?.Where(row => row.RowId == ExchangeItemId).FirstOrNull() ?? null;
            }

            public Achievement? GetAchievement(int achievementId)
            {
                return Service.LuminaSheet<Achievement>()?.Where(row => row.RowId == achievementId).FirstOrNull() ?? null;
            }

            public int GetCompletedAchievementsCount()
            {
                var count = 0;
                foreach (var item in ClassAchievementMap.Values)
                {
                    if (Util.GetIsComplete((uint)item))
                        count++;
                }
                return count;
            }

            public int GetRemainingItemCount(int currentCount)
            {
                var achievementCount = ClassAchievementMap.Count;
                return (achievementCount - currentCount) * ExchangeItemMultiplier;
            }

            public string GetRemainText()
            {
                var itemName = GetExchangeItem()?.Name ?? "";
                var count = GetRemainingItemCount(GetCompletedAchievementsCount());

                return $"Remaining {itemName}: {count}";
            }
        }
    }
}
