using System;
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
	[Guid("1C8B6F72-29F3-447C-9AA3-223CC8CB2858")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ECFs : List<AACECF>, IEnumerable<AACECF>
    {
        #region Constructor

        internal ECFs()
		{
		}

		#endregion Constructor

		#region IEnumerable<ACBrAACECF>

		IEnumerator<AACECF> IEnumerable<AACECF>.GetEnumerator()
        {
            int count = Count;
            for (int i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<AACECF>)this).GetEnumerator();
		}

		#endregion IEnumerable<ACBrAACECF>
	}
}