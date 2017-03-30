using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace clg1704
{
	public class ObservableCollectionCustomized<T> : ObservableCollection<T>
	{

		public void AddRange(IEnumerable<T> range)
		{
			const string RANGE = "range";

			if (range == null)
			{
				throw new ArgumentNullException(RANGE);
			}

			var items = range.ToList();
			int index = Items.Count;
			foreach (T item in range)
			{
				Items.Add(item);
			}

			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items, index));
		}
	}
}
