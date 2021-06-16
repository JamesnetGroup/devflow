using System.Collections;
using System.Collections.ObjectModel;

namespace DevFlow.Extensions
{
	public static class CollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable list)
        {
            collection.Clear();
            foreach (object item in list)
            {
                collection.Add((T)item);
            }
        }
    }
}
