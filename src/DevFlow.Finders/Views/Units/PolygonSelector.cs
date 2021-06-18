using DevFlow.Finders.Local.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Finders.Views
{
	public class PolygonSelector : ListBox
	{
		#region DefaultStyleKey

		static PolygonSelector()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(PolygonSelector), new FrameworkPropertyMetadata(typeof(PolygonSelector)));
		}
		#endregion

		#region DependencyProperties

		public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(FileModel), typeof(PolygonSelector), new PropertyMetadata(null, DataChanged));
		public static readonly DependencyProperty SelectionCommandProperty = DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(PolygonSelector));
		#endregion

		#region SelectionCommand

		public ICommand SelectionCommand
		{
			get => (ICommand)GetValue(SelectionCommandProperty);
			set => SetValue(SelectionCommandProperty, value);
		}
		#endregion

		#region Data

		public FileModel Data
		{
			get { return (FileModel)this.GetValue(DataProperty); }
			set { this.SetValue(DataProperty, value); }
		}
		#endregion

		#region Constructor

		public PolygonSelector()
		{ 
		
		}
		#endregion

		// DpendencyProperty Callback..♥

		#region DataChanged

		private static void DataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is PolygonSelector poly)
			{
				if (poly.Data != null)
				{
					List<LocatorModel> dirs = new List<LocatorModel>();
					string fullPath = poly.Data.FullPath;

					string[] colors =
					{
						"#00000000",
						"#FF8B9600",
						"#FFEDC33F",
						"#FF427AB3",
						"#FF8B9600",
						"#FFEDC33F",
						"#FF427AB3",
						"#FF8B9600",
						"#FFEDC33F",
						"#FF427AB3",
						"#FF8B9600",
						"#FFEDC33F",
						"#FF427AB3",
						"#FF8B9600",
						"#FFEDC33F",
						"#FF427AB3",
					};


					while (true)
					{
						var name = Path.GetFileName(fullPath);

						if (name == "")
						{
							var root = new LocatorModel(fullPath, fullPath, poly.PolygonClick);
							root.IsRoot = true;
							dirs.Insert(0, root);

							break;
						}
						else
						{
							var root = new LocatorModel(name, fullPath, poly.PolygonClick);
							dirs.Insert(0, root);
							fullPath = Path.GetDirectoryName(fullPath);
						}
					}

					int cnt = 0;
					dirs.ForEach(x => x.Color = colors[cnt++]);
					dirs.Last().IsLast = true;

					poly.ItemsSource = dirs;
				}
			}
		}
		#endregion

		// ICommand Action..♥

		#region PolygonClick

		private void PolygonClick(FileModel item)
		{
			SelectionCommand.Execute(item);
		}
		#endregion
	}
}
