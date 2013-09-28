using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class Prod
	{
		#region Constructor

		internal Prod()
		{
			VeicProd = new veicProd();
            Med = new MedCollection();
            Arma = new ArmaCollection();
		}

		#endregion Constructor

		#region Propriedades

        public string CProd { get; set; }

        public int NItem { get; set; }

        public string XProd { get; set; }

        public string CEAN { get; set; }

        public string NCM { get; set; }

        public string EXTIPI { get; set; }

        public string CFOP { get; set; }

        public string UCom { get; set; }

        public decimal QCom { get; set; }

        public decimal VUnCom { get; set; }

        public decimal VProd { get; set; }

        public string CEANTrib { get; set; }

        public string UTrib { get; set; }

        public decimal VUnTrib { get; set; }

        public decimal QTrib { get; set; }

        public decimal VFrete { get; set; }

        public decimal VSeg { get; set; }

        public decimal VDesc { get; set; }

        public decimal VOutro { get; set; }

        public IndicadorTotal IndTot { get; set; }

        public string XPed { get; set; }

        public int NItemPed { get; set; }

        public MedCollection Med { get; private set; }

        public ArmaCollection Arma { get; private set; }

		public veicProd VeicProd { get; private set; }

		#endregion Propriedades
	}
}