using DevFlow.Data.Works;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DevFlow.LayoutSupport.Controls
{
	public class Workspace : Canvas
	{
		public static readonly DependencyProperty WorksSourceProperty = DependencyProperty.Register("WorksSource", typeof(ObservableCollection<WorkspaceModel>), typeof(Workspace), new PropertyMetadata(null, ItemsSourceChanged));

		public ObservableCollection<WorkspaceModel> WorksSource
        {
            get { return (ObservableCollection<WorkspaceModel>)this.GetValue(WorksSourceProperty); }
            set { this.SetValue(WorksSourceProperty, value); }
		}

		private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((Workspace)d).OnItemsSourceChanged();
		}

		private void OnItemsSourceChanged()
		{
			Children.Clear();

			foreach (WorkspaceModel item in WorksSource)
			{
				AddChild(item);
			}

			WorksSource.CollectionChanged -= ItemsSource_CollectionChanged;
			WorksSource.CollectionChanged += ItemsSource_CollectionChanged;
		}

		private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			foreach (WorkspaceModel item in e.NewItems)
			{
				AddChild(item);
			}
		}

		private void AddChild(WorkspaceModel item)
		{
			if (item.Content is UIElement ui)
			{
				Children.Add(ui);
			}
		}
	}
}
