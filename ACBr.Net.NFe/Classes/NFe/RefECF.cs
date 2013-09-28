using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
	public sealed class RefECF
	{
		#region Constructor

		internal RefECF()
        {	
        }

		#endregion Constructor

		#region Properties

        public ECFModRef Modelo { get; set; }

        public string NECF { get; set; }

        public string NCOO { get; set; }

		#endregion Properties
	}
}
