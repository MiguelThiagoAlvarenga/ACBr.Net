using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class veicProd
	{
		#region Constructor

		internal veicProd()
		{

		}

		#endregion Constructor

		#region Propriedades

        public TipoOperacao TpOP { get; set; }

        public string Chassi { get; set; }

        public string CCor { get; set; }

        public string XCor { get; set; }

        public string Pot { get; set; }

        public string Cilin { get; set; }

        public string PesoL { get; set; }

        public string PesoB { get; set; }

        public string NSerie { get; set; }

        public string TpComb { get; set; }

        public string CombDescricao { get; private set; }

        public string NMotor { get; set; }

        public string CMT { get; set; }

        public string Dist { get; set; }

        public int AnoMod { get; set; }

        public int AnoFab { get; set; }

        public string TpPint { get; set; }

        public int TpVeic { get; set; }

        public int EspVeic { get; set; }

        public string VIN { get; set; }

        public CondicaoVeiculo CondVeic { get; set; }

        public string CMod { get; set; }

        public string CCorDENATRAN { get; set; }

        public int Lota { get; set; }

        public int TpRest { get; set; }

		#endregion Propriedades
	}
}
