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

    public static readonly Dawntrail.Penumbrae _dawntrailPenumbraeRelic = new();
    public static readonly Dawntrail.Umbrae _dawntrailUmbraeRelic = new();

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
        ImGui.Text(_dawntrailPenumbraeRelic.Name);
        Util.DrawRelicsTable(_dawntrailPenumbraeRelic.Data);
        ImGui.Spacing();
        ImGui.Text(_dawntrailPenumbraeRelic.Data.GetRemainText());

        ImGui.Spacing();
        ImGui.Text(_dawntrailUmbraeRelic.Name);
        Util.DrawRelicsTable(_dawntrailUmbraeRelic.Data);
        ImGui.Spacing();
        ImGui.Text(_dawntrailUmbraeRelic.Data.GetRemainText());
    }
}
