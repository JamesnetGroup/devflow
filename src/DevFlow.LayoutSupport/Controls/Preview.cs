using DevFlow.Controls.Primitives;
using System.Windows;

namespace DevFlow.LayoutSupport.Controls
{
    public class Preview : Widget
	{
		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(object), typeof(Preview), new PropertyMetadata(null));

		public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(object), typeof(Preview), new PropertyMetadata(null));

		public object Title
		{
			get { return (object)this.GetValue(TitleProperty); }
			set { this.SetValue(TitleProperty, value); }
		}

		public object SubTitle
		{
			get { return (object)this.GetValue(SubTitleProperty); }
			set { this.SetValue(SubTitleProperty, value); }
		}

		static Preview()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Preview), new FrameworkPropertyMetadata(typeof(Preview)));
		}

		public Preview()
		{
			//RenderTransform = new TranslateTransform(100, 100);
		}
    }
}




