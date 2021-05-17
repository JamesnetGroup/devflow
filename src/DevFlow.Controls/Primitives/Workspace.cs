using DevFlow.Data.Works;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DevFlow.Controls.Primitives
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
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (WorkspaceModel item in e.NewItems)
				{
					AddChild(item);
				}
			}

			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach (WorkspaceModel item in e.OldItems)
				{
					RemoveChild(item);
				}
			}
		}

		private void AddChild(WorkspaceModel item)
		{
			if (item.Content is UIElement ui)
			{
				Children.Add(ui);
			}
		}

		private void RemoveChild(WorkspaceModel item)
		{
			if (Children.Contains(item.Content as UIElement))
			{
				Children.Remove(item.Content as UIElement);
			}
		}

		internal void Remove(UIElement ui)
		{
			if (WorksSource.FirstOrDefault(x => x.Content.Equals(ui)) is WorkspaceModel item)
			{
				WorksSource.Remove(item);
			}
		}
	}
}
