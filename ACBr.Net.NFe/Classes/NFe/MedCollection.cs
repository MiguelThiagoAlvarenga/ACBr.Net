using System;
using System.Collections;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
    public sealed class MedCollection : IEnumerable<MedCollectionItem>
    {
        #region Fields

        List<MedCollectionItem> list;

        #endregion Fields

        #region Constructor

        internal MedCollection()
        {
            list = new List<MedCollectionItem>();
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

        public MedCollectionItem this[int idx]
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

        public MedCollectionItem AddNew()
        {
            var med = new MedCollectionItem();
            list.Add(med);
            return med;
        }

        public void Clear()
        {
            list.Clear();
        }

        #endregion Methods

        #region IEnumerable<MedCollectionItem>

        public IEnumerator<MedCollectionItem> GetEnumerator()
        {
            int count = Count;
            for (int i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion IEnumerable<NotasFiscais>
    }
}