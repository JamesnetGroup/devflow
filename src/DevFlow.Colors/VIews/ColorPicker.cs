using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using DevFlow.LayoutSupport.Controls;
using Gma.System.MouseKeyHook;

namespace DevFlow.Colors.Views
{
	public class ColorPicker : ColorPickerBase
    {
        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }

        public ColorPicker()
        { 
        
        }
    }
}
