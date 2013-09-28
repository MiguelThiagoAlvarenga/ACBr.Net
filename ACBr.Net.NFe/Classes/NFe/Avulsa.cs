using System;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class Avulsa
	{
		#region Constructor

		internal Avulsa()
		{

		}

		#endregion Constructor

		#region Properties

        public string CNPJ { get; set; }

        public string Fone { get; set; }

        public string Matr { get; set; }

        public string NDAR { get; set; }

        public string RepEmi { get; set; }

        public string UF { get; set; }

        public string VDAR { get; set; }

        public string XAgente { get; set; }

        public string XOrgao { get; set; }

        public DateTime DEmi 
        {
            get; 
            set; 
        }

        public DateTime DPag { get; set; }
		
		#endregion Properties
	}
}
