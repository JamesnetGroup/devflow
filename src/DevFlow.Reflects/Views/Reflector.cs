using DevFlow.LayoutSupport.Controls;
using System.Windows;

namespace DevFlow.Reflects.Views
{
    public class Reflector : BasicWindow
    {
        static Reflector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Reflector), new FrameworkPropertyMetadata(typeof(Reflector)));
        }
    }
}
