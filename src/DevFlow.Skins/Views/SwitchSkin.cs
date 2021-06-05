using DevFlow.LayoutSupport.Controls;
using System.Windows;

namespace DevFlow.Skins.Views
{
    public class SwitchSkin : Preview
	{
		static SwitchSkin()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchSkin), new FrameworkPropertyMetadata(typeof(SwitchSkin)));
		}

		public SwitchSkin()
		{
		}

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

    }
}
