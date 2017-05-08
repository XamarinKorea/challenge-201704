using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace RandomUsers.Lib
{

    public class ObservableList<T> : ObservableCollection<T>
    {
        public ObservableList() : base()
        {
        }
        public ObservableList(IEnumerable<T> source):base(source)
        {
        }
        public void AddRange(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");

            var items = range.ToList();
            int index = Items.Count;
            foreach (T item in range)
                Items.Add(item);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items, index));
        }
    }
}