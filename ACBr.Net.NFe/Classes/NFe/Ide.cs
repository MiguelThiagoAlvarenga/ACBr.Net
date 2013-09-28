using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class Ide
	{
		#region Constructor

		internal Ide()
		{
			this.NFrefCollection = new NFref();
		}

		#endregion Constructor

		#region Properties

        public int CUF { get; set; }

        public int CNF { get; set; }

        public string NatOp { get; set; }

        public IndicadorPagamento IndPag { get; set; }

        public int Modelo { get; set; }

        public int Serie { get; set; }

		public int NNF { get; set; }

        public DateTime DEmi { get; set; }

        public DateTime DSaiEnt { get; set; }

        public DateTime HSaiEnt { get; set; }

        public TipoNFe TpNF { get; set; }

        public int CMunFG { get; set; }

		public NFref NFrefCollection { get; private set; }
		public RefNFP RefNFP { get; private set; }

        public TipoImpressao TpImp { get; set; }

        public TipoEmissao TpEmis { get; set; }

        public int CDV { get; set; }

        public TipoAmbiente TpAmb { get; set; }

        public FinalidadeNFe FinNFe { get; set; }

        public ProcessoEmissao ProcEmi { get; set; }

        public string VerProc { get; set; }

        public DateTime DhCont { get; set; }

        public string XJust { get; set; }

		#endregion Properties
	}
}