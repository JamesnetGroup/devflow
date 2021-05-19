using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DevFlow.LayoutSupport.Controls
{
    public class Palette : Preview
    {
        public static readonly DependencyProperty DragCaptureCommandProperty = DependencyProperty.Register("DragCaptureCommand", typeof(ICommand), typeof(Palette));

        public ICommand DragCaptureCommand
        {
            get { return (ICommand)this.GetValue(DragCaptureCommandProperty); }
            set { this.SetValue(DragCaptureCommandProperty, value); }
        }

        public Palette()
        {
        }


        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            if (e.OriginalSource is DropImageCanvas cnavas)
            {
                BeginCapture();
            }
        }

        int previewWidth = 2;
        int previewHeight = 2;
        private IKeyboardMouseEvents globalMouseHook;

        private void BeginCapture()
        {
            globalMouseHook = Hook.GlobalEvents();
            globalMouseHook.MouseMove += MainWindow_MouseMove;
            globalMouseHook.MouseUp += MainWindow_MouseUp;
            Mouse.OverrideCursor = Cursors.Cross;
        }

        private void EndCapture()
        {
            globalMouseHook.MouseMove -= MainWindow_MouseMove;
            globalMouseHook.MouseUp -= MainWindow_MouseUp;
            globalMouseHook.Dispose();
            Mouse.OverrideCursor = null;
        }

        private void MainWindow_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
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
                    DragCaptureCommand?.Execute(new object[] { bmpSource, new System.Windows.Media.Color() { R = color.R, G = color.G, B = color.B, A = color.A } });
                }
            }
        }

        private void MainWindow_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            EndCapture();
        }
    }
}

