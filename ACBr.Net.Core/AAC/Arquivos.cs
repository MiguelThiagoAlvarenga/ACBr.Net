using System.Linq;
using System.Collections;
using System.Collections.Generic;

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
	[Guid("E2B492E7-B180-41AB-A922-484DE27A5281")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class Arquivos : List<Arquivo> ,IEnumerable<Arquivo>
	{
		#region Constructor

		internal Arquivos()
		{
		}

		#endregion Constructor

		#region Methods

		public Arquivo New()
		{
            var item = new Arquivo();
            Add(item);
            return item;
		}

		#endregion Methods

		#region IEnumerable<ACBrAACArquivo>

		IEnumerator<Arquivo> IEnumerable<Arquivo>.GetEnumerator()
        {
            int count = Count;
            for (int i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Arquivo>)this).GetEnumerator();
		}

		#endregion IEnumerable<ACBrAACArquivo>
	}
}