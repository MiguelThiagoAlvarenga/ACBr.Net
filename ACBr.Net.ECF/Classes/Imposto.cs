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
	[Guid("2D204F15-3B9A-4918-88C0-4C37CD234696")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

#endregion COM_INTEROP

	public sealed class Imposto
	{
		#region Constructor

		internal Imposto()
		{
		}

		#endregion Constructor

		#region Properties

        public string Texto { get; set; }

        public string Fonte { get; set; }

        public decimal ValorAproximado
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }

		#endregion Properties
	}
}
