using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility.Raii;
using FFXIVClientStructs.FFXIV.Common.Math;
using System.Linq;
using static RelicTracker.Data.General;

namespace RelicTracker
{
    public class Util
    {
        public static void DrawRelicsTable(IRelicData relicData)
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
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.TextUnformatted(p.Key.Name.ToString());

                    ImGui.TableNextColumn();
                    ImGui.TextUnformatted(p.Value.Description.ToString());

                    ImGui.TableNextColumn();
                    var active = GetIsComplete(p.Value.RowId);

                    using var color = new ImRaii.Color();
                    color.Push(ImGuiCol.TextDisabled, !active ? ImGuiColors.DalamudRed : ImGuiColors.ParsedGreen);

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

        public static unsafe bool GetIsComplete(uint RowId)
        {
            var achievement = FFXIVClientStructs.FFXIV.Client.Game.UI.Achievement.Instance();
            if (!achievement->IsLoaded())
            {
                return false;
            }
            return achievement->IsComplete((int)RowId);
        }
    }
}
