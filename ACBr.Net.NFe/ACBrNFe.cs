using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ACBr.Net.Core;

namespace ACBr.Net.NFe
{
    #region COM Interop

    /* NOTAS para COM INTEROP
	 * Há um modo de compilação com a diretiva COM_INTEROP que inseri atributos e código específico
	 * para a DLL ser exportada para COM (ActiveX)
	 *
	 * O modelo COM possui alguma limitações/diferenças em relação ao modelo .NET
	 * Inserir os #if COM_INTEROP para prover implementações distintas nas modificações necessárias para COM:
	 *
	 * - Inserir atributos ComVisible(true), Guid("xxx") e ClassInterface(ClassInterfaceType.AutoDual) em todas as classes envolvidas
	 *
	 * - Propriedades/métodos que usam "Decimal" devem incluir o atributo MarshalAs(UnmanagedType.Currency)
	 *   usar [return: ...] para retornos de métodos e propriedades ou [param: ...] para o set de propriedades
	 *
	 * - Métodos que recebem array como parâmetros devem fazer como "ref".
	 *   Propriedades só podem retornar arrays, nunca receber.
	 *
	 * - Overload não é permitido. Métodos com mesmos nomes devem ser renomeados.
	 *   É possível usar parâmetros default, simplificando a necessidade de Overload
	 *
	 * - Generic não deve ser usado. Todas as classes Generic devem ser re-escritas como classes específicas
	 *
	 * - Eventos precisam de uma Interface com as declarações dos métodos (eventos) com o atributo [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	 *   A classe que declara os eventos precisa do atributo [ComSourceInterfaces(typeof(INomeDaInterface))]
	 *   Nenhum delegate deverá ser Generic, precisam ser re-escritos.
	 *
	 *   OBS: Por padrão o modelo .Net recebe os eventos com a assinatura void(object sender, EventArgs e)
	 *   O modelo COM não precisa desses parâmetros. Assim o delegate EventHandler foi redefinido para uma assinatura void()
	 *   Outros EventArgs devem seguir a assitarua COM void(MyEventArg e) ao invés da assinatura .NET void(object sender, MyEventArgs e)
	 * */

#if COM_INTEROP

    #region IDispatch Interface

    #region Documentation

	/// <summary>
	/// Interface contendo os eventos publicados pelo componente COM
	/// </summary>

    #endregion Documentation

    #endregion IDispatch Interface

    #region Delegates

    #region Comments

	///os componentes COM não suportam Generics
	///Estas são implementações específicas de delegates que no .Net são representados como EventHandler<T>

    #endregion Comments

	public delegate void AbreCupomEventHandler(AbreCupomEventArgs e);

	public delegate void RelatorioGerencialEventHandler(RelatorioGerencialEventArgs e);

	public delegate void CancelaItemEventHandler(CancelaItemEventArgs e);

	public delegate void BobinaAdicionaLinhasEventHandler(BobinaAdicionaLinhasEventArgs e);

	public delegate void EfetuaPagamentoEventHandler(EfetuaPagamentoEventArgs e);

	public delegate void FechaCupomEventHandler(FechaCupomEventArgs e);

	public delegate void SangriaSuprimentoEventHandler(SangriaSuprimentoEventArgs e);

	public delegate void SubtotalizaCupomEventHandler(SubtotalizaCupomEventArgs e);

	public delegate void VendeItemEventHandler(VendeItemEventArgs e);

	public delegate void ChangeEstadoEventHandler(ChangeEstadoEventArgs e);

	public delegate void ChequeEstadoEventHandler(ChequeEstadoEventArgs e);

	public delegate void OnErrorEventHandler(ErrorEventArgs e);

	public delegate void OnErrorRelatorioEventHandler(ErrorRelatorioEventArgs e);

	public delegate void OnMsgEventHandler(MsgEventArgs e);

	public delegate void OnMsgRetentarEventHandler(MsgRetentarEventArgs e);

	public delegate void OnPAFCalcEADEventHandler(PAFCalcEADEventArgs e);

	public delegate void ChaveEventHandler(ChaveEventArgs e);

    #endregion Delegates

#endif

    #endregion COM Interop

    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
    [Guid("CBA87758-FD2A-41CF-ADA4-3D2784847915")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes

	[ToolboxBitmap(typeof(ACBrNFE), @"ACBr.Net.NFE.ico.bmp")]
	public class ACBrNFE : ACBrComponent
	{
		#region Events
				
		#endregion Events

		#region Fields
		#endregion Fields

		#region Constructor

		public ACBrNFE()
		{
            
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public NFEConfiguracoes Configuracoes { get; private set; }

		[Browsable(false)]
		public NotasFiscais NotasFiscais { get; private set; }
			
		#endregion Properties

		#region Methods

		#region Funções

		#endregion Funções

		#region EventHandlers

		#endregion EventHandlers

		#region Override Methods

		protected override void OnInitialize()
		{
            Configuracoes = new NFEConfiguracoes();
            NotasFiscais = new NotasFiscais();
        }

		protected override void OnDisposing()
		{			
		}

		#endregion Override Methods

		#endregion Methods
	}
}