using DevFlow.Data.Menu;
using DevFlow.Data.Works;
using DevFlow.Windowbase.Flowbase;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DevFlow.Controls.Primitives
{
	public class Widget : FlowView
    {
        private bool _isDragging;
		private Point clickPosition;

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
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Parent is Workspace workspace)
            {
                workspace.Remove(this);
            }
        }

        private void Widget_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			_isDragging = true;
			var draggableControl = sender as DragBorder;
			clickPosition = e.GetPosition(draggableControl);
			draggableControl.CaptureMouse();
		}

        private void Widget_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
			_isDragging = false;
			var draggable = sender as DragBorder;
			draggable.ReleaseMouseCapture();

            if (this.RenderTransform is TranslateTransform transform)
            {
                FlowConfig.SaveLocation(MenuInfo, transform.X, transform.Y, ActualWidth, ActualHeight);
            }
        }

        private void Widget_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isDragging && sender is DragBorder)
            {
                Point currentPosition = e.GetPosition(Parent as Canvas);

                if (!(this.RenderTransform is TranslateTransform transform))
                {
                    transform = new TranslateTransform();
                    this.RenderTransform = transform;
                }

                transform.X = currentPosition.X - clickPosition.X;
                transform.Y = currentPosition.Y - clickPosition.Y;
            }
        }
	}
}
