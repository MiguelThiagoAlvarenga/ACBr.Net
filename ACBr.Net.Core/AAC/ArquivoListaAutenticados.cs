#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBr.Net.Core.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("4CDBFAB2-9CC6-4D31-8B19-42183EC2E24F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ArquivoListaAutenticados
	{
		#region Constructor

		internal ArquivoListaAutenticados()
		{
		}

		#endregion Constructor

		#region Properties

        public string Nome { get; set; }

        public string MD5 { get; set; }

		#endregion Properties
	}
}