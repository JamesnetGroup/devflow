using DevFlow.Finders.Local.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DevFlow.Finders.Views
{
	public class PolygonSelector : Control
	{
		public ListBox LocationSelector { get; set; }

		#region DefaultStyleKey

		static PolygonSelector()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(PolygonSelector), new FrameworkPropertyMetadata(typeof(PolygonSelector)));
		}
		#endregion

		#region DependencyProperties

		public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(FileModel), typeof(PolygonSelector), new PropertyMetadata(null, DataChanged));
		#endregion
		public FileModel Data
		{
			get { return (FileModel)this.GetValue(DataProperty); }
			set { this.SetValue(DataProperty, value); }
		}


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
						"#FF427AB3",
						"#FFCDAC00",
						"#FF8B9600",
						"#FF427AB3",
						"#FFCDAC00",
						"#FF8B9600",
						"#FF427AB3",
						"#FFCDAC00",
						"#FF8B9600",
						"#FF427AB3",
						"#FFCDAC00",
						"#FF8B9600",
						"#FF427AB3",
						"#FFCDAC00",
						"#FF8B9600",
						"#FF427AB3",
						"#FFCDAC00",
						"#FF8B9600",
						"#FF427AB3",
						"#FFCDAC00",
						"#FF8B9600",
					};

					int cnt = 0;

					while (true)
					{
						var name = Path.GetFileName(fullPath);

						if (name == "")
						{
							var root = new LocatorModel(fullPath, colors[cnt]);
							root.IsRoot = true;
							dirs.Insert(0, root);

							break;
						}
						else
						{
							dirs.Insert(0, new LocatorModel(name, colors[cnt]));
							fullPath = Path.GetDirectoryName(fullPath);
						}
						cnt++;
					}

					poly.LocationSelector.ItemsSource = dirs;
				}
			}
		}

		public override void OnApplyTemplate()
		{
			if (GetTemplateChild("PART_LocationSelector") is ListBox stack)
			{
				LocationSelector = stack;
			}
		}
	}
	public class LocatorModel
	{
		public LocatorModel(string name, string color)
		{
			Name = name;
			Color = color;
		}

		public string Name { get; set; }
		public string Color { get; set; }
		public bool IsRoot { get; set; }
	}
}
