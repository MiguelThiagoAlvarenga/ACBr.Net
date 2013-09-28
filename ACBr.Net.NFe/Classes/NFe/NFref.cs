using System;
using System.Collections;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class NFref: IEnumerable<NFrefCollectionItem>
    {
        #region Fields

        List<NFrefCollectionItem> list;

        #endregion Fields

        #region Constructor

        internal NFref()
		{

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

		public NFrefCollectionItem this[int idx]
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

		public NFrefCollectionItem AddNew()
		{
            var item = new NFrefCollectionItem();
            list.Add(item);
            return item;
		}

		public void Clear()
		{
            list.Clear();
		}

		#endregion Methods

		#region IEnumerable<NotasFiscais>

		public IEnumerator<NFrefCollectionItem> GetEnumerator()
		{
            return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable<NotasFiscais>
	}
}