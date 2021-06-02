using DevFlow.Serialization.Data;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevFlow.Colors.Local.Capture
{
	public class PixelExtractWorker
    {
        // 임시 버퍼의 graphic 타입
        private Bitmap buffer = new Bitmap(1, 1);
        private Graphics buffer_graphics = null;
        private IKeyboardMouseEvents globalMouseHook;
        public Action<ColorStruct> Extract = (p) => { };
        public Action Exit = () => { };
        public PixelExtractWorker()
        {
            this.buffer_graphics = Graphics.FromImage(buffer);
        }

        internal void Begin()
        {
            BeginCapture();
        }

        private void BeginCapture()
        {
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
            globalMouseHook.MouseMove -= MainWindow_MouseMove;
            globalMouseHook.MouseUp -= MainWindow_MouseUp;
            globalMouseHook.MouseDown -= GlobalMouseHook_MouseDown;
            globalMouseHook.Dispose();
            Mouse.OverrideCursor = null;
        }
        private void MainWindow_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            EndCapture();
            Exit();
        }
        private void MainWindow_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            SetView(e.X, e.Y);
        }

        int count = 0;
        private void SetView(int x, int y, bool capture = false)
        {
            if (count > 3)
            {
                count = 0;
                var color = new ColorStruct(ScreenColor(x, y));
                Extract(color);
            }
            else
            {
                count++;
            }
        }
        private Color ScreenColor(int x, int y)
        {
            // Mouse 위치의 색을 추출한다.
            this.buffer_graphics.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(1, 1));
            // Pixel 값을 리턴한다.
            return this.buffer.GetPixel(0, 0);
        }
	}
}
