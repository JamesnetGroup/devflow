using DevFlow.Controls.Primitives;
using DevFlow.Data.Menu;
using DevFlow.Data.Settings;
using DevFlow.Windowbase.Flowbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.LayoutSupport.Controls
{
	public class Explorer : FlowWindow
	{
		#region DependencyProperties

		public static readonly DependencyProperty TitleTemplateProperty = DependencyProperty.Register("TitleTemplate", typeof(DataTemplate), typeof(Explorer), new PropertyMetadata(null));
		public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(object), typeof(Explorer), new PropertyMetadata(null));
		#endregion

		#region DefaultStyleKey

		static Explorer()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Explorer), new FrameworkPropertyMetadata(typeof(Explorer)));
		}
		#endregion

		#region Variables

		protected bool IsFixedSize;
		protected MenuModel MenuInfo;
		#endregion

		#region TitleTemplate

		public DataTemplate TitleTemplate
		{
			get => (DataTemplate)GetValue(TitleTemplateProperty);
			set => SetValue(TitleTemplateProperty, value);
		}
		#endregion

		#region SubTitle

		public object SubTitle
		{
			get => GetValue(SubTitleProperty);
			set => SetValue(SubTitleProperty, value);
		}
		#endregion

		#region Options

		public List<ViewOptionModel> Options => FlowConfig.Config.ViewOptions;
		#endregion

		#region Constructor

		public Explorer()
		{
			WindowStyle = WindowStyle.None;
			ResizeMode = ResizeMode.CanResize;
			AllowsTransparency = true;
			////WindowChrome.SetWindowChrome(this, new WindowChrome { ResizeBorderThickness = new Thickness(1) });
		}
		#endregion

		#region OnApplyTemplate

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
		#endregion

		private void Bar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				GetWindow(this).DragMove();
			}
		}

		public override void OnShow(MenuModel menu)
		{
			MenuInfo = menu;

			var options = FlowConfig.Config.ViewOptions;

			ViewOptionModel option = (from q in FlowConfig.Config.ViewOptions
									  where q.IconType == menu.IconType
									  select q).FirstOrDefault();

			if (option is ViewOptionModel view)
			{
				Left = view.LocX;
				Top = view.LocY;

				if (!IsFixedSize)
				{
					Width = view.Width;
					Height = view.Height;
				}
			}
			Show();
		}

		#region OnClosed

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			FlowConfig.SaveLocation(MenuInfo, (int)Left, (int)Top, (int)ActualWidth, (int)ActualHeight);
		}
		#endregion
	}
}
