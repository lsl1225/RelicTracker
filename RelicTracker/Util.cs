using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility.Raii;
using FFXIVClientStructs.FFXIV.Common.Math;
using Lumina.Excel.Sheets;
using RelicTracker.Data;
using System;
using System.Linq;
using static RelicTracker.Data.General;

namespace RelicTracker
{
    public class Util
    {
        public static void DrawRelicsTable(IRelicPhaseData relicData)
        {
            var flags =
                ImGuiTableFlags.Borders |
                ImGuiTableFlags.RowBg |
                ImGuiTableFlags.Resizable |
                ImGuiTableFlags.ScrollY;

            Vector2 size = new(0, 300);

            if (ImGui.BeginTable("relic_table", 3, flags, size))
            {
                ImGui.TableSetupScrollFreeze(0, 1);

                ImGui.TableSetupColumn("Class", ImGuiTableColumnFlags.WidthFixed, 350);
                ImGui.TableSetupColumn("Description");
                ImGui.TableSetupColumn("Completed", ImGuiTableColumnFlags.WidthFixed, 220);

                ImGui.TableHeadersRow();

                for (var i = 0; i < relicData.ClassAchievementMap.Count; i++)
                {
                    var p = relicData.ClassAchievementMap.ElementAt(i);
                    var job = GetJob(p.Key);
                    var achi = GetAchievement(p.Value);

                    if (job == null || achi == null)
                    {
                        throw new Exception();
                    }

                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.TextUnformatted(job.Value.Name.ToString());

                    ImGui.TableNextColumn();
                    ImGui.TextUnformatted(achi.Value.Description.ToString());

                    ImGui.TableNextColumn();
                    var active = GetAchievementIsComplete(achi.Value.RowId);

                    ImRaii.PushColor(ImGuiCol.TextDisabled, !active ? ImGuiColors.DalamudRed : ImGuiColors.ParsedGreen);

                    using (ImRaii.PushFont(UiBuilder.IconFont))
                    {
                        if (active)
                        {
                            ImGui.TextDisabled(FontAwesomeIcon.Check.ToIconString());
                        }
                        else
                        {
                            ImGui.TextDisabled(FontAwesomeIcon.Times.ToIconString());
                        }
                    }

                    ImGui.PopID();
                }

                ImGui.EndTable();
            }
        }

        public static unsafe bool GetAchievementIsComplete(uint RowId)
        {
            var achievement = FFXIVClientStructs.FFXIV.Client.Game.UI.Achievement.Instance();
            if (!achievement->IsLoaded())
            {
                return false;
            }
            return achievement->IsComplete((int)RowId);
        }

        public static Achievement? GetAchievement(int achievementId)
        {
            return Service.LuminaSheet<Achievement>()?.GetRow((uint)achievementId) ?? null;
        }

        public static ClassJob? GetJob(Job jobId)
        {
            return Service.LuminaSheet<ClassJob>()?.GetRow((uint)jobId) ?? null;
        }
    }
}
