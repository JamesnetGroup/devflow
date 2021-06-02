using DevFlow.Data.Menu;
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
        private bool IsResizing;
        public bool IsFixedSize;

        public WorkspaceModel MenuInfo;

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(object), typeof(Widget), new PropertyMetadata(null));

        public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(object), typeof(Widget), new PropertyMetadata(null));

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

        public Widget()
        {
        }
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






