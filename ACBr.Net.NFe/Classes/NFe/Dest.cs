using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class Dest
	{
		#region Constructor

		internal Dest()
		{
			this.EnderDest = new EnderDest();
		}

		#endregion Constructor

		#region Properties

        public string CNPJCPF { get; set; }

        public string IE { get; set; }

        public string ISUF { get; set; }

        public string XNome { get; set; }

        public string Email { get; set; }

		public EnderDest EnderDest { get; private set; }

		#endregion Properties
	}
}