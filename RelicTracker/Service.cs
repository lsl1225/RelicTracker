using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using Lumina;
using Lumina.Excel;

namespace RelicTracker
{
    public class Service
    {
        public static void Initialize(IDalamudPluginInterface pluginInterface) => pluginInterface.Create<Service>();

        [PluginService] public static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
        [PluginService] public static ITextureProvider TextureProvider { get; private set; } = null!;
        [PluginService] public static ICommandManager CommandManager { get; private set; } = null!;
        [PluginService] public static IClientState ClientState { get; private set; } = null!;
        [PluginService] public static IDataManager DataManager { get; private set; } = null!;
        [PluginService] public static IPluginLog Log { get; private set; } = null!;

        public static GameData LuminaGameData => DataManager.GameData;
        public static ExcelSheet<T>? LuminaSheet<T>() where T : struct, IExcelRow<T> => LuminaGameData?.GetExcelSheet<T>(Lumina.Data.Language.English);
        public static SubrowExcelSheet<T>? LuminaSheetSubrow<T>() where T : struct, IExcelSubrow<T> => LuminaGameData?.GetSubrowExcelSheet<T>(Lumina.Data.Language.English);
        public static T? LuminaRow<T>(uint row) where T : struct, IExcelRow<T> => LuminaSheet<T>()?.GetRowOrDefault(row);
        public static SubrowCollection<T>? LuminaSubrows<T>(uint row) where T : struct, IExcelSubrow<T> => LuminaSheetSubrow<T>()?.GetRowOrDefault(row);
        public static T? LuminaRow<T>(uint row, ushort subRow) where T : struct, IExcelSubrow<T> => LuminaSheetSubrow<T>()?.GetSubrowOrDefault(row, subRow);
    }
}
