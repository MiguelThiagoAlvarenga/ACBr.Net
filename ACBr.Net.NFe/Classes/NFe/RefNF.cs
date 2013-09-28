using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
	public sealed class RefNF
	{
		#region Constructor

		public RefNF()
		{
		}

		#endregion Constructor

		#region Properties

        public int CUF { get; set; }

        public string AAMM { get; set; }

        public string CNPJ { get; set; }

        public int Modelo { get; set; }

        public int Serie { get; set; }

        public int NNF { get; set; }

		#endregion Properties
	}
}
