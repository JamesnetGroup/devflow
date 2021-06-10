using DevFlow.Controls.Primitives;
using DevFlow.Data.Menu;
using DevFlow.Data.Settings;
using DevFlow.Windowbase.Flowbase;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.LayoutSupport.Controls
{
	public class Explorer : FlowWindow
	{
		protected bool IsFixedSize;
		protected MenuModel MenuInfo;

		public static readonly DependencyProperty TitleTemplateProperty = DependencyProperty.Register("TitleTemplate", typeof(DataTemplate), typeof(Explorer), new PropertyMetadata(null));

		public DataTemplate TitleTemplate
		{
			get => (DataTemplate)GetValue(TitleTemplateProperty);
			set => SetValue(TitleTemplateProperty, value);
		}


		static Explorer()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Explorer), new FrameworkPropertyMetadata(typeof(Explorer)));
		}

		public Explorer()
		{
			WindowStyle = WindowStyle.None;
			ResizeMode = ResizeMode.CanResize;
			AllowsTransparency = true;
			////WindowChrome.SetWindowChrome(this, new WindowChrome { ResizeBorderThickness = new Thickness(1) });
		}

		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseDown(e);
		}

		public override void OnApplyTemplate()
		{
			if (GetTemplateChild("PART_CloseButton") is Button btn)
			{
				btn.Click += (s, e) => Close();
			}
			if (GetTemplateChild("PART_DragBar") is DragBorder bar)
			{
				bar.MouseDown += Bar_MouseDown;
			}
		}

		private void Bar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				GetWindow(this).DragMove();
			}
		}

		public override void Show(MenuModel menu)
		{
			if (FlowConfig.Config.ViewOptions.FirstOrDefault(x => x.IconType == menu.IconType) is ViewOptionModel view)
			{
				Left = view.LocX;
				Top = view.LocY;

				if (!IsFixedSize)
				{
					Width = view.Width;
					Height = view.Height;
				}
			}
			MenuInfo = menu;
			Show();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			FlowConfig.SaveLocation(MenuInfo, (int)Left, (int)Top, (int)ActualWidth, (int)ActualHeight);
		}
	}
}
