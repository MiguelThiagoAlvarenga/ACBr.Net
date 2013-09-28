using System;
using System.Text;
using System.ComponentModel;

namespace ACBr.Net.NFe
{
	public sealed class NFECFGArquivos
	{
		#region Constructor

		internal NFECFGArquivos()
		{

		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
        public bool AdicionarLiteral { get; set; }

		[Browsable(true)]
        public bool EmissaoPathNFe { get; set; }

		[Browsable(true)]
        public bool Salvar { get; set; }

		[Browsable(true)]
        public bool PastaMensal { get; set; }

		[Browsable(true)]
        public string PathNFe { get; set; }

		[Browsable(true)]
        public string PathCan { get; set; }

		[Browsable(true)]
        public string PathInu { get; set; }

		[Browsable(true)]
        public string PathDPEC { get; set; }

		[Browsable(true)]
        public string PathCCe { get; set; }

		[Browsable(true)]
        public string PathMDe { get; set; }

		[Browsable(true)]
        public string PathEvento { get; set; }

		#endregion Properties

		#region Methods

		public string GetPathCan()
		{
			return PathCan;
		}

		public string GetPathInu()
		{
			return PathInu;
		}

		public string GetPathDPEC()
		{
			return PathDPEC;
		}

		public string GetPathNFe(DateTime Data)
        {
            return string.Empty;
		}

		public string GetPathCCe()
		{
            return PathCCe;
		}

		public string GetPathMDe()
		{
            return PathCCe;
		}

		public string GetPathEvento(TpEvento evento)
		{
            return PathEvento;
		}

		#endregion Methods

	}
}