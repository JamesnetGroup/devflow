using DevFlow.LayoutSupport.Controls;
using System.Windows;

namespace DevFlow.Histories.Views
{
    public class History : Preview
    {
        static History()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(History), new FrameworkPropertyMetadata(typeof(History)));
        }
    }
}
