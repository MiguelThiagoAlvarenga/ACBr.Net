using System;
using System.Text;
using System.ComponentModel;

namespace ACBr.Net.NFe
{
	public sealed class NFECFGCertificados
	{
		#region Constructor

		internal NFECFGCertificados()
		{

		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
        public string Certificado { get; set; }

		[Browsable(true)]
        public string Senha { get; set; }

		#endregion Properties

		#region Methods

		#endregion Methods
	}
}