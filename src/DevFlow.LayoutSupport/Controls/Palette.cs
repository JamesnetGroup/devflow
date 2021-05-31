using Gma.System.MouseKeyHook;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DevFlow.LayoutSupport.Controls
{
    public class Palette : Preview
    {
        public static readonly DependencyProperty DragCaptureCommandProperty = DependencyProperty.Register("DragCaptureCommand", typeof(ICommand), typeof(Palette)); 
        public static readonly DependencyProperty IsCaptureColorProperty = DependencyProperty.Register("IsCaptureColor", typeof(bool), typeof(Palette), new PropertyMetadata(false));
    
        public bool IsCaptureColor
        {
            get { return (bool)this.GetValue(IsCaptureColorProperty); }
            set { this.SetValue(IsCaptureColorProperty, value); }
        }

        public ICommand DragCaptureCommand
        {
            get { return (ICommand)this.GetValue(DragCaptureCommandProperty); }
            set { this.SetValue(DragCaptureCommandProperty, value); }
        }
        private Bitmap buffer = new Bitmap(1, 1);
        // 임시 버퍼의 graphic 타입
        private Graphics buffer_graphics = null;



        public Palette()
        {
            this.buffer_graphics = Graphics.FromImage(buffer);
            IsFixedSize = true;
        }


        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            if (e.OriginalSource is DropImageCanvas canvas)
            {
                BeginCapture();
            }
        }
        private Color ScreenColor(int x, int y)
        {
            // Mouse 위치의 색을 추출한다.
            this.buffer_graphics.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(1, 1));
            // Pixel 값을 리턴한다.
            return this.buffer.GetPixel(0, 0);
        }
        int count = 0;
        private void SetView(int x, int y, bool capture = false)
        {

            if (count > 3)
            {
                count = 0;
                var color = ScreenColor(x, y);
                DragCaptureCommand?.Execute(new byte[] { color.R, color.G, color.B, color.A });
            }
            else
            {
                count++;
            }
        }





        int previewWidth = 2;
        int previewHeight = 2;
        private IKeyboardMouseEvents globalMouseHook;

        private void BeginCapture()
        {
            IsCaptureColor = true;
            globalMouseHook = Hook.GlobalEvents();
            globalMouseHook.MouseMove += MainWindow_MouseMove;
            globalMouseHook.MouseDown += GlobalMouseHook_MouseDown;
            Mouse.OverrideCursor = Cursors.Cross;
        }

        private void GlobalMouseHook_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            globalMouseHook.MouseUp += MainWindow_MouseUp;
        }

        private void EndCapture()
        {
            IsCaptureColor = false;
            globalMouseHook.MouseMove -= MainWindow_MouseMove;
            globalMouseHook.MouseUp -= MainWindow_MouseUp;
            globalMouseHook.MouseDown -= GlobalMouseHook_MouseDown;
            globalMouseHook.Dispose();
            Mouse.OverrideCursor = null;
        }

        private void MainWindow_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            SetView(e.X, e.Y);

            return;

            using (var screenBmp = new Bitmap(previewWidth, previewHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (var bmpGraphics = Graphics.FromImage(screenBmp))
                {
                    bmpGraphics.CopyFromScreen(e.Location.X - (previewWidth / 2), e.Location.Y - (previewHeight / 2), 0, 0, new System.Drawing.Size(previewWidth, previewHeight));
                    var bmpSource = Imaging.CreateBitmapSourceFromHBitmap(
                        screenBmp.GetHbitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());

                    var color = screenBmp.GetPixel(previewWidth / 2, previewWidth / 2);
                    DragCaptureCommand?.Execute(new byte[] {  color.R , color.G, color.B, color.A } );
                }
            }
        }

        private void MainWindow_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            EndCapture();
        }
    }
}

