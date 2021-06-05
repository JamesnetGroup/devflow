using DevFlow.Data;
using DevFlow.Data.Settings;
using DevFlow.Data.Works;
using System;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DevFlow.Windowbase.Flowbase
{
    public class FlowConfig
    {
        public static string WIN_PATH { get; }
        public static string SYS_PATH { get; }
        public static string CFG_PATH { get; }
        public static ConfigModel Config { get; private set; }

        static FlowConfig()
        {
            WIN_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            SYS_PATH = string.Format(@"{0}\DevFlow\System", WIN_PATH);
            CFG_PATH = string.Format(@"{0}\Config.yaml", SYS_PATH);

            LoadConfigFile();
        }

        private static void LoadConfigFile()
        {
            if (!Directory.Exists(SYS_PATH))
            {
                Directory.CreateDirectory(SYS_PATH);
            }

            if (!File.Exists(CFG_PATH))
            {
                SaveConfig(new ConfigModel());
            }

            var deserializer = new DeserializerBuilder()
              .WithNamingConvention(CamelCaseNamingConvention.Instance)
              .Build();

            Config = deserializer.Deserialize<ConfigModel>(File.ReadAllText(CFG_PATH));
        }

        public static void SaveLanguage(LanguageType lang)
        {
            Config.Language = lang;
            SaveConfig(Config);
        }

        public static void SaveTheme(ThemeType theme)
        {
            Config.Theme = theme;
            SaveConfig(Config);
        }

        public static ConfigModel LoadConfig()
        {
            return Config;
        }

		public static void SaveLocation(WorkspaceModel menu, int x, int y, int width, int height)
		{
            if (Config.ViewOptions.FirstOrDefault(x => menu.Menu.IconType == x.IconType) is ViewOptionModel view)
            {
                view.LocX = x;
                view.LocY = y;
                view.Width = width;
                view.Height = height;
            }
            else
            {
                Config.ViewOptions.Add(new ViewOptionModel { IconType = menu.Menu.IconType, LocX = x, LocY = y, Width = width, Height = height });
            }

            SaveConfig(Config);
		}

		private static void SaveConfig(ConfigModel config)
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var yaml = serializer.Serialize(config);

            File.WriteAllText(CFG_PATH, yaml);
        }
    }
}
  