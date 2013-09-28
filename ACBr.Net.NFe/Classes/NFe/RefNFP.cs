using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class RefNFP
	{
		#region Constructor

		public RefNFP()
		{
		}

		#endregion Constructor

		#region Properties

        public int CUF { get; set; }

        public string AAMM { get; set; }

        public string CNPJCPF { get; set; }

        public string IE { get; set; }

        public string Modelo { get; set; }

        public int Serie { get; set; }

        public int NNF { get; set; }

		#endregion Properties
	}
}
