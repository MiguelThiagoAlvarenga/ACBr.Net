using System;
using System.Collections;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class DetCollection : List<DetCollectionItem>, IEnumerable<DetCollectionItem>
	{
		#region Constructor

		internal DetCollection()
		{

		}

		#endregion Constructor

		#region Properties


		#endregion Properties

		#region Methods

		public DetCollectionItem AddNew()
		{
            var item = new DetCollectionItem();
            base.Add(item);
            return item;
		}

		#endregion Methods

		#region IEnumerable<DetCollectionItem>

		public IEnumerator<DetCollectionItem> GetEnumerator()
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable<NotasFiscais>
	}
}