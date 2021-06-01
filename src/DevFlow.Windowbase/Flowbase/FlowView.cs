using DevFlow.Windowbase.Flowcore;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DevFlow.Windowbase.Flowbase
{
	public class FlowView : ContentControl, IFlowElement
    {
		public Window Window { get; private set; }

		#region DependencyProperty

		public static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.Register("MouseDownCommand", typeof(ICommand), typeof(FlowView));
		#endregion

		#region MouseDownCommand

		public ICommand MouseDownCommand
		{
			get { return (ICommand)this.GetValue(MouseDownCommandProperty); }
			set { this.SetValue(MouseDownCommandProperty, value); }
		}
		#endregion

		#region Constructor

		public FlowView()
        {
			Loaded += FlowView_Loaded;
        }
		#endregion

		#region UseMvvm

		public IFlowElement UseMvvm(ObservableObject vm)
        {
            DataContext = vm;
            return this;
        }
		#endregion

		#region Show

		public void Show()
		{
			Window = new Window
			{
				Content = this,
				AllowsTransparency = true,
				WindowStyle = WindowStyle.None,
				SizeToContent = SizeToContent.WidthAndHeight
			};
			Window.Show();
		}
		#endregion

		#region OnDesignerMode

		protected virtual void OnDesignerMode()
        {

        }
		#endregion

		#region Loaded

		private void FlowView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                OnDesignerMode();
            }

            if (DataContext is ObservableObject vm)
            {
                vm.ViewRegister(this);
            }
        }
		#endregion
	}
}
