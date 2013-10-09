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
	[Guid("9D0EF24E-5B1A-4EDE-8189-E70AC3419085")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class RodapeNotaLegalDF
	{
		#region Constructor

		internal RodapeNotaLegalDF()
		{
		}

		#endregion Constructor

		#region Properties

        public bool Imprimir { get; set; }

        public bool ProgramaDeCredito { get; set; }

        public decimal ValorICMS
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

        public decimal ValorISS
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;

            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            set;
        }

		#endregion Properties
	}
}