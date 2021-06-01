using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Colors.Local.Collection
{
	public class FixedColorCollection<T> : ICollection
	{
		private ObservableCollection<T> Source { get; }

		public int Count => Source.Count;

		public object SyncRoot => throw new NotImplementedException();

		public bool IsSynchronized => throw new NotImplementedException();

		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public FixedColorCollection()
		{
			Source = new();
		}
	}
}
