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
#endif
	#endregion COM_INTEROP
	public enum TipoFuncionamento
	{
		StandAlone = 0,
		EmRede = 1,
		Parametrizavel = 2
	}
}