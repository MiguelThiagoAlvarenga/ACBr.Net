#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBr.Net.Core.ECF
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
#endif

	#endregion COM_INTEROP

	public enum TipoContador
	{
		COO,
		CRZ
	}
}