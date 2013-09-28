using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class EnderEmit
	{
		#region Constructor

		internal EnderEmit()
		{

		}

		#endregion Constructor

		#region Properties

        public int CEP { get; set; }

        public int CMun { get; set; }

        public int CPais { get; set; }

        public string Fone { get; set; }

        public string Nro { get; set; }

        public string UF { get; set; }

        public string XBairro { get; set; }

        public string XCpl { get; set; }

        public string XLgr { get; set; }

        public string XMun { get; set; }

        public string XPais { get; set; }

		#endregion Properties
	}
}