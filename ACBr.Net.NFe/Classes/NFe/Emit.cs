using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
    public sealed class Emit
	{
		#region Constructor

		internal Emit()
		{
			this.EnderEmit = new EnderEmit();
		}

		#endregion Constructor

		#region Properties
                
        public string CNAE { get; set; }

        public string CNPJCPF { get; set; }

        public string IE { get; set; }

        public string IEST { get; set; }

        public string IM { get; set; }

        public string XFant { get; set; }

        public string XNome { get; set; }

        public CRT CRT { get; set; }

		public EnderEmit EnderEmit { get; private set; }

		#endregion Properties
	}
}