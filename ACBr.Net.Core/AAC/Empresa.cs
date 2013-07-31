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
	[Guid("17376497-6E66-4E59-BBB8-680EC6A19697")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class Empresa
	{
		#region Constructor

		internal Empresa()
		{
		}

		#endregion Constructor

		#region Properties

        public string CNPJ { get; set; }

        public string RazaoSocial { get; set; }

        public string Endereco { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Telefone { get; set; }

        public string Contato { get; set; }

        public string Email { get; set; }

        public string IE { get; set; }

        public string IM { get; set; }

		#endregion Properties
	}
}