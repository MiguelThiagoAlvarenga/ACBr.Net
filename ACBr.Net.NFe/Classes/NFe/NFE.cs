using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
    public sealed class NFe
	{
		#region Fields
		#endregion Fields

		#region Constructor

		internal NFe()
		{
			Emit = new Emit();
			InfNFE = new InfNFe();
			Avulsa = new Avulsa();
			Retirada = new Retirada();
			Entrega = new Entrega();
			Det = new DetCollection();
            Total = new Total();
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
        public Total Total { get; private set; }
        
		#endregion Properties

		#region Methods
		#endregion Methods
	}

    [Serializable]
    public sealed class Total
    {
        #region Constructor
        
        internal Total()
        {
            ICMSTot = new ICMSTot();
        }

        #endregion Constructor

        #region Propriedades

        public ICMSTot ICMSTot { get; private set; }
        //public ISSQNtot ISSQNtot { get; private set; }
        //public retTrib retTrib { get; private set; }

        #endregion Propriedades
    }
}
