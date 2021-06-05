using DevFlow.Data.Works;
using DevFlow.Windowbase.Flowbase;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace DevFlow.Controls.Primitives
{
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
                FlowConfig.SaveLocation(MenuInfo, (int)transform.X, (int)transform.Y, (int)ActualWidth, (int)ActualHeight);
            }
        }

        private void Widget_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
			if (_isDragging && sender is DragBorder)
			{
                //Window.GetWindow(this).DragMove();
                //Point currentPosition = e.GetPosition(Parent as Canvas);

                //if (!(this.RenderTransform is TranslateTransform transform))
                //{
                //	transform = new TranslateTransform();
                //	this.RenderTransform = transform;
                //}

                //transform.X = currentPosition.X - clickPosition.X;
                //transform.Y = currentPosition.Y - clickPosition.Y;
            }


		}

        private void Btn_DragDelta(object sender, DragDeltaEventArgs e)
        {
            IsResizing = true;
            var yadjust = this.Height + e.VerticalChange;
            var xadjust = this.Width + e.HorizontalChange;
            if ((xadjust >= 0) && (yadjust >= 0))
            {
                this.Width = xadjust;
                this.Height = yadjust;
                _ = (Parent as Canvas);
            }
        }

        private void Btn_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (this.RenderTransform is TranslateTransform transform)
            {
                FlowConfig.SaveLocation(MenuInfo, (int)transform.X, (int)transform.Y, (int)ActualWidth, (int)ActualHeight);
            }
        }
    }
}






