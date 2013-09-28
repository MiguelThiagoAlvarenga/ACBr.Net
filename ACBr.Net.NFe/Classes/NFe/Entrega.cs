using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class Entrega
	{
		#region Constructor

		internal Entrega()
		{

		}

		#endregion Constructor

		#region Properties

        public int CMun { get; set; }

        public string CNPJCPF { get; set; }

        public string XLgr { get; set; }

        public string Nro { get; set; }

        public string XCpl { get; set; }

        public string XBairro { get; set; }

        public string XMun { get; set; }

        public string UF { get; set; }

		#endregion Properties
	}
}
