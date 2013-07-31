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
	[Guid("37DC86EF-999A-4992-9945-FB334DF3FEC6")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class Restaurante
	{
		#region Constructor

		internal Restaurante()
		{
		}

		#endregion Constructor

		#region Properties

        public bool Imprimir { get; set; }

        public int ECF { get; set; }

        public int COO { get; set; }

        public int CER { get; set; }

        public string Mesa { get; set; }

		#endregion Properties
	}
}