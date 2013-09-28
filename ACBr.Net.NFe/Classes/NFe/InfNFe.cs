using System;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class InfNFe
	{
		#region Constructor

		internal InfNFe()
		{

		}

		#endregion Constructor

		#region Properties

        public string ID { get; set; }

        public decimal Versao { get; set; }

        public string VersaoStr { get; set; }

		#endregion Properties
	}
}
