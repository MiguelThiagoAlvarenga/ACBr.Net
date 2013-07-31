#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBr.Net.ECF
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("3DC074C6-C53F-476B-BCCD-E8C97B9D29EF")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class Rodape
	{
		#region Constructor

		internal Rodape()
		{
			NotaLegalDF = new RodapeNotaLegalDF();
			Restaurante = new Restaurante();
			Imposto = new Imposto();
		}

		#endregion Constructor

		#region Properties

		public string Dav { get; set; }

        public string DavOs { get; set; }

        public string MD5 { get; set; }

        public string PreVenda { get; set; }

        public bool CupomMania { get; set; }

        public bool MinasLegal { get; set; }

        public bool ParaibaLegal { get; set; }

		public RodapeNotaLegalDF NotaLegalDF { get; private set; }

		public Restaurante Restaurante { get; private set; }

		public Imposto Imposto { get; private set; }

		#endregion Properties
	}
}