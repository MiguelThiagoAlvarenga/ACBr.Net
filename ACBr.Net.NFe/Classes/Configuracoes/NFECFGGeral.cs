using System;
using System.ComponentModel;

namespace ACBr.Net.NFe
{
	public sealed class NFECFGGeral
	{
		#region Constructor

		internal NFECFGGeral()
		{

		}

		#endregion Constructor

		#region Properties

        [Browsable(true)]
        public TipoEmissao FormaEmissao { get; set; }

		[Browsable(true)]
        public int FormaEmissaoCodigo { get; set; }

		[Browsable(true)]
        public bool Salvar { get; set; }

		[Browsable(true)]
        public bool AtualizarXMLCancelado { get; set; }

		[Browsable(true)]
        public string PathSalvar { get; set; }

		[Browsable(true)]
        public string PathSchemas { get; set; }

		[Browsable(true)]
        public bool IniFinXMLSECAutomatico { get; set; }

		#endregion Properties

		#region Methods

		public bool Save(string AXMLName, string AXMLFile, string aPath)
        {
            return true;
		}

		#endregion Methods

	}
}