using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility.Raii;
using Dalamud.Interface.Windowing;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Common.Math;
using RelicTracker.Data;
using System;
using Achievement = FFXIVClientStructs.FFXIV.Client.Game.UI.Achievement;

namespace RelicTracker.Windows;

public class MainWindow : Window, IDisposable
{
    private readonly Plugin plugin;
    private bool achievementsRequested;

    public static readonly Dawntrail _dawntrail_relic = new();

    public MainWindow(Plugin plugin)
        : base("Relic Tracker##RelicTrackerMain", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(720, 360),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.plugin = plugin;
    }

    public void Dispose() { }

    public override unsafe void Draw()
    {
        if (!AgentLobby.Instance()->IsLoggedIn)
        {
            ImGui.Text("Not logged in."u8);
            return;
        }

        var achievement = Achievement.Instance();
        if (!achievement->IsLoaded())
        {
            using (ImRaii.Disabled(achievement->ProgressRequestState == Achievement.AchievementState.Requested))
            {
                if (ImGui.Button("Request Achievements List"))
                {
                    AgentAchievement.Instance()->Show();
                    achievementsRequested = true;
                }
            }

            return;
        }
        else
        {
            ImGui.Text("Achievements Loaded."u8);
        }

        if (achievementsRequested)
        {
            AgentAchievement.Instance()->Hide();
            achievementsRequested = false;
        }

        ImGui.Spacing();
        Util.DrawRelicsTable(_dawntrail_relic.Penumbrae);
        ImGui.Spacing();

        ImGui.Text($"Remaining {_dawntrail_relic.Penumbrae.ExchangeItem!.Value.Name}: {(_dawntrail_relic.Penumbrae.ClassAchievementMap.Count - _dawntrail_relic.Penumbrae.GetCompletedCount()) * _dawntrail_relic.Penumbrae.ExchangeItemMultiplier}");

        ImGui.Spacing();
        Util.DrawRelicsTable(_dawntrail_relic.Umbrae);
        ImGui.Spacing();

        ImGui.Text($"Remaining {_dawntrail_relic.Umbrae.ExchangeItem!.Value.Name}: {(_dawntrail_relic.Umbrae.ClassAchievementMap.Count - _dawntrail_relic.Umbrae.GetCompletedCount()) * _dawntrail_relic.Umbrae.ExchangeItemMultiplier}");
    }
}
