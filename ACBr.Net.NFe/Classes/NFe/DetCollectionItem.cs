using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class DetCollectionItem
	{
		#region Constructor

		internal DetCollectionItem()
		{
			Prod = new Prod();
		}

		#endregion Constructor

		#region Propriedades

		public Prod Prod { get; private set; }

		#endregion Propriedades
	}
}