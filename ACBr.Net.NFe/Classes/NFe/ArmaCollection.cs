using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
    public sealed class ArmaCollection : IEnumerable<ArmaCollectionItem>
    {
        #region Fields

        List<ArmaCollectionItem> list;

        #endregion Fields

        #region Constructor

        internal ArmaCollection()
        {
            list = new List<ArmaCollectionItem>();
        }

        #endregion Constructor

        #region Properties

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public ArmaCollectionItem this[int idx]
        {
            get
            {
                if (idx >= Count || idx < 0)
                    throw new IndexOutOfRangeException();

                return list[idx];
            }
            set
            {
                if (idx >= Count || idx < 0)
                    throw new IndexOutOfRangeException();

                list[idx] = value;
            }
        }

        #endregion Properties

        #region Methods

        public ArmaCollectionItem AddNew()
        {
            var item = new ArmaCollectionItem();
            list.Add(item);
            return item;
        }

        public void Clear()
        {
            list.Clear();
        }

        #endregion Methods

        #region IEnumerable<ArmaCollectionItem>

        public IEnumerator<ArmaCollectionItem> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion IEnumerable<NotasFiscais>
    }
}
