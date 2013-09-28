using System;
using System.Text;
using System.ComponentModel;

namespace ACBr.Net.NFe
{
	public sealed class NFECFGWebServices
	{
		#region Constructor

		public NFECFGWebServices()
		{

		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
        public bool Visualizar { get; set; }

		[Browsable(true)]
        public NFeUF UF { get; set; }

		[Browsable(true)]
        public int UFCodigo { get; set; }

		[Browsable(true)]
        public TipoAmbiente Ambiente { get; set; }

        [Browsable(true)]
        public int AmbienteCodigo { get; private set; }

		[Browsable(true)]
        public string ProxyHost { get; set; }

		[Browsable(true)]
        public string ProxyPort { get; set; }

		[Browsable(true)]
        public string ProxyUser { get; set; }

		[Browsable(true)]
        public string ProxyPass { get; set; }

		[Browsable(true)]
        public uint AguardarConsultaRet { get; set; }

		[Browsable(true)]
        public int Tentativas { get; set; }

		[Browsable(true)]
        public bool AjustaAguardaConsultaRet { get; set; }

		#endregion Properties

		#region Methods

		#endregion Methods
	}
}
