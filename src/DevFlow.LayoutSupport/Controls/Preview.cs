using DevFlow.Windowbase.Flowbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevFlow.LayoutSupport.Controls
{
	public class Preview : FlowView
	{
		static Preview()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Preview), new FrameworkPropertyMetadata(typeof(Preview)));
		}

		public Preview()
		{
			RenderTransform = new TranslateTransform(100, 100);
		}
	}
}
