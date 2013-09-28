using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
    public sealed class NFE
	{
		#region Fields
		#endregion Fields

		#region Constructor

		internal NFE()
		{
			Emit = new Emit();
			InfNFE = new InfNFe();
			Avulsa = new Avulsa();
			Retirada = new Retirada();
			Entrega = new Entrega();
			Det = new DetCollection();
		}

		#endregion Constructor

		#region Properties

        public Schema Schema { get; set; }
		public InfNFe InfNFE { get; private set; }
		public Emit Emit { get; private set; }
		public Avulsa Avulsa { get; private set; }
		public Retirada Retirada { get; private set; }
		public Entrega Entrega { get; private set; }
		public DetCollection Det { get; private set; }

		#endregion Properties

		#region Methods
		#endregion Methods
	}
}
