using System;
using System.Windows;

namespace DevFlow.Windowbase.Design
{
    public class ResourceMerger
    {
        public static ResourceDictionary Black { get; private set; }
        public static ResourceDictionary White { get; private set; }

        public static void Initialize()
        {
            Black = new ResourceDictionary { Source = new Uri("/DevFlow.Resources;component/Theme/Black.xaml", UriKind.RelativeOrAbsolute) };
            White = new ResourceDictionary { Source = new Uri("/DevFlow.Resources;component/Theme/White.xaml", UriKind.RelativeOrAbsolute) };
            Application.Current.Resources.MergedDictionaries.Add(Black);
        }
    }
}
