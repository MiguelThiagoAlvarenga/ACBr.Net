using System;
using System.ComponentModel;

namespace ACBr.Net.NFe
{
	public sealed class NFEConfiguracoes
	{
		#region Constructor

		internal NFEConfiguracoes()
		{
			this.Geral = new NFECFGGeral();
			this.Arquivos = new NFECFGArquivos();
			this.Certificados = new NFECFGCertificados();
			this.WebServices = new NFECFGWebServices();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public NFECFGGeral Geral { get; private set; }

		[Browsable(true)]
		public NFECFGArquivos Arquivos { get; private set; }

		[Browsable(true)]
		public NFECFGCertificados Certificados { get; private set; }

		[Browsable(true)]
		public NFECFGWebServices WebServices { get; private set; }

		#endregion Properties

		#region Methods
		#endregion Methods

	}
}