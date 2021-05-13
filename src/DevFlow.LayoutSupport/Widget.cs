using DevFlow.Windowbase.Flowbase;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DevFlow.LayoutSupport
{
	public class Widget : FlowView
    {
        private bool _isDragging;
		private Point clickPosition;

		public Widget()
        {
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_DragBar") is DragBar bar)
            {
                bar.MouseLeftButtonDown += Widget_MouseLeftButtonDown;
                bar.MouseLeftButtonUp += Widget_MouseLeftButtonUp;
                bar.MouseMove += Widget_MouseMove;
            }
        }

        private void Widget_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			_isDragging = true;
			var draggableControl = sender as DragBar;
			clickPosition = e.GetPosition(draggableControl);
			draggableControl.CaptureMouse();
		}

        private void Widget_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
			_isDragging = false;
			var draggable = sender as DragBar;
			draggable.ReleaseMouseCapture();
		}

        private void Widget_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isDragging && sender is DragBar)
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
