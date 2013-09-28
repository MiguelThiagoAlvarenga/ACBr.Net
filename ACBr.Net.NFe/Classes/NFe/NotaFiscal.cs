using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
	public sealed class NotaFiscal
	{
		#region Fields
		#endregion Fields

		#region Constructor

		internal NotaFiscal()
		{
            NFe = new NFE();
		}

		#endregion Constructor

		#region Properties

        public NFE NFe { get; private set; }

        public string Alertas { get; set; }

        public string XML { get; set; }

        public string Msg { get; set; }

        public string NomeArq { get; set; }

        public bool Confirmada { get; set; }

		#endregion Properties

		#region Methods

		public void Imprimir()
		{
			
		}

		public void ImprimirPDF()
		{
			
		}

		public bool SaveToFile(string arquivo, bool TXT = false)
		{
            return true;
		}

		public void EnviarEmail(string sSmtpHost, string sSmtpPort, string sSmtpUser, string sSmtpPasswd,
			        string sFrom, string sTo, string sAssunto, string[] sMensagem, bool SSL, bool EnviaPDF = true,
			        string[] sCC = null, string[] sAnexos = null, bool PedeConfirma = false, 
			        bool AguardarEnvio = false, string NomeRemetente = "", bool TLS = true, bool UsarThread = true)
		{
			
		}

		#endregion Methods
	}
}