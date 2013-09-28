using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class NFrefCollectionItem
	{
		#region Constructor

		internal NFrefCollectionItem()
		{
			RefNF = new RefNF();
			RefNFP = new RefNFP();
			RefECF = new RefECF();
		}

		#endregion Constructor

		#region Properties

        public string RefNFe { get; set; }

        public string RefCTe { get; set; }

		public RefNF RefNF { get; private set; }

		public RefNFP RefNFP { get; private set; }

		public RefECF RefECF { get; private set; }

		#endregion Properties
	}
}