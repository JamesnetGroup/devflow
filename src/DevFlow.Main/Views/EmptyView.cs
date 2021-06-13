using System.Windows;
using DevFlow.LayoutSupport.Controls;

namespace DevFlow.Main.Views
{
    public class EmptyView : Explorer
    {
        #region DefaultStyleKey

        static EmptyView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EmptyView), new FrameworkPropertyMetadata(typeof(EmptyView)));
        }
        #endregion
    }
}
