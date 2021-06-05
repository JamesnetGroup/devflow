<<<<<<< HEAD
﻿using DevFlow.Data.Works;
=======
﻿using DevFlow.Data.Menu;
using DevFlow.Data.Settings;
>>>>>>> 2a576b7fde0e188b9e62ab3008e9d6f90580709d
using DevFlow.Windowbase.Flowbase;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DevFlow.Controls.Primitives
{
<<<<<<< HEAD
    public class Widget : FlowView
    {
        private bool _isDragging;
        private bool IsResizing;
        private Point clickPosition;
        public bool IsFixedSize;

        public WorkspaceModel MenuInfo;


        public Widget()
        {
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_DragBar") is DragBorder bar)
            {
                bar.MouseLeftButtonDown += Widget_MouseLeftButtonDown;
                bar.MouseLeftButtonUp += Widget_MouseLeftButtonUp;
                bar.MouseMove += Widget_MouseMove;
            }

            if (GetTemplateChild("PART_CloseButton") is Button btn)
            {
                btn.Click += Btn_Click;
            }

            if (GetTemplateChild("PART_Resize") is Thumb thumb)
            {
                thumb.DragDelta += Btn_DragDelta;
                thumb.DragCompleted += Btn_DragCompleted;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Parent is Workspace workspace)
            {
                workspace.Remove(this);
            }
        }

        private void Widget_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
=======
	public class Widget : FlowView
	{
		public bool IsFixedSize;
		public bool IsResizing;
		public MenuModel MenuInfo;

		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(object), typeof(Widget), new PropertyMetadata(null));

		public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(object), typeof(Widget), new PropertyMetadata(null));

		public object Title
		{
			get => GetValue(TitleProperty);
			set => SetValue(TitleProperty, value);
		}

		public object SubTitle
		{
			get => GetValue(SubTitleProperty);
			set => SetValue(SubTitleProperty, value);
		}

		public Widget()
>>>>>>> 2a576b7fde0e188b9e62ab3008e9d6f90580709d
		{
			IsResizing = false;
		}

		#region Show

		public override void Show(MenuModel menu)
		{
			Window = new Window
			{
				Content = this,
				AllowsTransparency = true,
				WindowStyle = WindowStyle.None,
				SizeToContent = SizeToContent.WidthAndHeight
			};
			Window.Closed += Window_Closed;

			ShowWindow(menu);

		}

		private void ShowWindow(MenuModel menu)
		{
			if (FlowConfig.Config.ViewOptions.FirstOrDefault(x => x.IconType == menu.IconType) is ViewOptionModel view)
			{
				Window.Left = view.LocX;
				Window.Top = view.LocY;

				if (this is Widget ui && !ui.IsFixedSize)
				{
					Window.Width = view.Width;
					Window.Height = view.Height;
				}
			}
			MenuInfo = menu;
			Window.Show();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Closed(Window);
		}
		#endregion

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			if (GetTemplateChild("PART_DragBar") is DragBorder bar)
			{
				bar.MouseMove += Widget_MouseMove;
			}

			if (GetTemplateChild("PART_CloseButton") is Button btn)
			{
				btn.Click += Btn_Click;
			}

			if (GetTemplateChild("PART_Resize") is Thumb thumb)
			{
				thumb.DragDelta += Btn_DragDelta;
				thumb.DragCompleted += Btn_DragCompleted;
			}
		}

		private void Btn_Click(object sender, RoutedEventArgs e)
		{
			Window.GetWindow(sender as UIElement).Close();
		}

		private void Widget_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
			{
				Window.GetWindow(this).DragMove();
			}
		}

		private void Btn_DragDelta(object sender, DragDeltaEventArgs e)
		{
			IsResizing = true;
			double yadjust = Height + e.VerticalChange;
			double xadjust = Width + e.HorizontalChange;
			if ((xadjust >= 0) && (yadjust >= 0))
			{
				Width = xadjust;
				Height = yadjust;
				_ = Parent as Canvas;
			}
		}

		private void Btn_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			FlowConfig.SaveLocation(MenuInfo, (int)Window.Left, (int)Window.Top, (int)ActualWidth, (int)ActualHeight);
		}
	}
}