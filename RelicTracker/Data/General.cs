using Lumina.Excel.Sheets;
using System.Collections.Generic;

namespace RelicTracker.Data
{
    public class General
    {
        public class IRelicData
        {
            public Item? ExchangeItem { get; set; } = null;

            public int ExchangeItemMultiplier { get; set; } = 0;

            public Dictionary<ClassJob, Achievement> ClassAchievementMap { get; set; } = new();

            public int GetCompletedCount()
            {
                var count = 0;
                foreach (var item in ClassAchievementMap.Values)
                {
                    if (Util.GetIsComplete(item.RowId))
                        count++;
                }
                return count;
            }
        }
    }
}
