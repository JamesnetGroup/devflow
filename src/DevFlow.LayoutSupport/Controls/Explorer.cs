using DevFlow.Controls.Primitives;
using System.Windows;

namespace DevFlow.LayoutSupport.Controls
{
	public class Explorer : Widget
	{
		public static readonly DependencyProperty TitleTemplateProperty = DependencyProperty.Register("TitleTemplate", typeof(DataTemplate), typeof(Explorer), new PropertyMetadata(null));
    
		public DataTemplate TitleTemplate
		{
			get { return (DataTemplate)this.GetValue(TitleTemplateProperty); }
			set { this.SetValue(TitleTemplateProperty, value); }
		}

		static Explorer()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Explorer), new FrameworkPropertyMetadata(typeof(Explorer)));
		}
	}
}
