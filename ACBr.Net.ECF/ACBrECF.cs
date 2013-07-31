using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ACBr.Net.Core;
using ACBr.Net.Core.AAC;
using ACBr.Net.Core.ECF;
using ACBr.Net.Core.Interface;
using ACBr.Net.ECF.Events;

namespace ACBr.Net.ECF
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

	[ComVisible(true)]
	[Guid("EB11262D-1650-41D0-8235-4774384C6631")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IACBrECFEvents
	{
		[DispId(1)]
		void OnMsgPoucoPapel();

		[DispId(2)]
		void OnAguardandoRespostaChange();

		[DispId(3)]
		void OnAntesAbreCupom(AbreCupomEventArgs e);

		[DispId(4)]
		void OnAntesAbreCupomVinculado();

		[DispId(5)]
		void OnAntesAbreNaoFiscal(AbreCupomEventArgs e);

		[DispId(6)]
		void OnAntesAbreRelatorioGerencial(RelatorioGerencialEventArgs e);

		[DispId(7)]
		void OnAntesCancelaCupom();

		[DispId(8)]
		void OnAntesCancelaItemNaoFiscal(CancelaItemEventArgs e);

		[DispId(9)]
		void OnAntesCancelaItemVendido(CancelaItemEventArgs e);

		[DispId(10)]
		void OnAntesCancelaNaoFiscal();

		[DispId(11)]
		void OnAntesEfetuaPagamento(EfetuaPagamentoEventArgs e);

		[DispId(12)]
		void OnAntesEfetuaPagamentoNaoFiscal(EfetuaPagamentoEventArgs e);

		[DispId(13)]
		void OnAntesFechaCupom(FechaCupomEventArgs e);

		[DispId(14)]
		void OnAntesFechaNaoFiscal(FechaCupomEventArgs e);

		[DispId(15)]
		void OnAntesFechaRelatorio();

		[DispId(16)]
		void OnAntesLeituraX();

		[DispId(17)]
		void OnAntesReducaoZ();

		[DispId(18)]
		void OnAntesSangria(SangriaSuprimentoEventArgs e);

		[DispId(19)]
		void OnAntesSubtotalizaCupom(SubtotalizaCupomEventArgs e);

		[DispId(20)]
		void OnAntesSubtotalizaNaoFiscal(SubtotalizaCupomEventArgs e);

		[DispId(21)]
		void OnAntesSuprimento(SangriaSuprimentoEventArgs e);

		[DispId(22)]
		void OnAntesVendeItem(VendeItemEventArgs e);

		[DispId(23)]
		void OnBobinaAdicionaLinhas(BobinaAdicionaLinhasEventArgs e);

		[DispId(24)]
		void OnChangeEstado(ChangeEstadoEventArgs e);

		//[DispId(25)]
		//void OnChequeEstado(ChequeEstadoEventArgs e);

		[DispId(26)]
		void OnDepoisAbreCupom(AbreCupomEventArgs e);

		[DispId(27)]
		void OnDepoisAbreCupomVinculado();

		[DispId(28)]
		void OnDepoisAbreNaoFiscal(AbreCupomEventArgs e);

		[DispId(29)]
		void OnDepoisAbreRelatorioGerencial(RelatorioGerencialEventArgs e);

		[DispId(30)]
		void OnDepoisCancelaCupom();

		[DispId(31)]
		void OnDepoisCancelaItemNaoFiscal(CancelaItemEventArgs e);

		[DispId(32)]
		void OnDepoisCancelaItemVendido(CancelaItemEventArgs e);

		[DispId(33)]
		void OnDepoisCancelaNaoFiscal();

		[DispId(34)]
		void OnDepoisEfetuaPagamento(EfetuaPagamentoEventArgs e);

		[DispId(35)]
		void OnDepoisEfetuaPagamentoNaoFiscal(EfetuaPagamentoEventArgs e);

		[DispId(36)]
		void OnDepoisFechaCupom(FechaCupomEventArgs e);

		[DispId(37)]
		void OnDepoisFechaNaoFiscal(FechaCupomEventArgs e);

		[DispId(38)]
		void OnDepoisFechaRelatorio();

		[DispId(39)]
		void OnDepoisLeituraX();

		[DispId(40)]
		void OnDepoisReducaoZ();

		[DispId(41)]
		void OnDepoisSangria(SangriaSuprimentoEventArgs e);

		[DispId(42)]
		void OnDepoisSubtotalizaCupom(SubtotalizaCupomEventArgs e);

		[DispId(43)]
		void OnDepoisSubtotalizaNaoFiscal(SubtotalizaCupomEventArgs e);

		[DispId(44)]
		void OnDepoisSuprimento(SangriaSuprimentoEventArgs e);

		[DispId(45)]
		void OnDepoisVendeItem(VendeItemEventArgs e);

		[DispId(46)]
		void OnErrorAbreCupom(ErrorEventArgs e);

		[DispId(47)]
		void OnErrorAbreCupomVinculado(ErrorEventArgs e);

		[DispId(48)]
		void OnErrorAbreNaoFiscal(ErrorEventArgs e);

		[DispId(49)]
		void OnErrorAbreRelatorioGerencial(ErrorRelatorioEventArgs e);

		[DispId(50)]
		void OnErrorCancelaCupom(ErrorEventArgs e);

		[DispId(51)]
		void OnErrorCancelaItemNaoFiscal(ErrorEventArgs e);

		[DispId(52)]
		void OnErrorCancelaItemVendido(ErrorEventArgs e);

		[DispId(53)]
		void OnErrorCancelaNaoFiscal(ErrorEventArgs e);

		[DispId(54)]
		void OnErrorEfetuaPagamento(ErrorEventArgs e);

		[DispId(55)]
		void OnErrorEfetuaPagamentoNaoFiscal(ErrorEventArgs e);

		[DispId(56)]
		void OnErrorFechaCupom(ErrorEventArgs e);

		[DispId(57)]
		void OnErrorFechaNaoFiscal(ErrorEventArgs e);

		[DispId(58)]
		void OnErrorFechaRelatorio(ErrorEventArgs e);

		[DispId(59)]
		void OnErrorLeituraX(ErrorEventArgs e);

		[DispId(60)]
		void OnErrorReducaoZ(ErrorEventArgs e);

		[DispId(61)]
		void OnErrorSangria(ErrorEventArgs e);

		[DispId(62)]
		void OnErrorSemPapel();

		[DispId(63)]
		void OnErrorSubtotalizaCupom(ErrorEventArgs e);

		[DispId(64)]
		void OnErrorSubtotalizaNaoFiscal(ErrorEventArgs e);

		[DispId(65)]
		void OnErrorSuprimento(ErrorEventArgs e);

		[DispId(66)]
		void OnErrorVendeItem(ErrorEventArgs e);

		[DispId(67)]
		void OnMsgAguarde(MsgEventArgs e);

		[DispId(68)]
		void OnMsgRetentar(MsgRetentarEventArgs e);

		//[DispId(69)]
		//void OnPAFCalcEAD(PAFCalcEADEventArgs e);

		//[DispId(70)]
		//void OnPAFGetKeyRSA(ChaveEventArgs e);
	}

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
	[Guid("7F5440D4-8D62-441B-9251-E911437D5F8F")]
	[ComSourceInterfaces(typeof(IACBrECFEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM Interop Attributes

    [ToolboxBitmap(typeof(ToolboxIcons), @"ACBr.Net.ECF.ico.bmp")]
    public sealed class ACBrECF : ACBrComponent, IDisposable
    {
        #region Events

        public event EventHandler OnMsgPoucoPapel;
        public event EventHandler OnAguardandoRespostaChange;
        public event EventHandler OnAntesAbreCupomVinculado;
        public event EventHandler OnAntesCancelaCupom;
        public event EventHandler OnAntesCancelaNaoFiscal;
        public event EventHandler OnAntesFechaRelatorio;
        public event EventHandler OnAntesLeituraX;
        public event EventHandler OnAntesReducaoZ;
        public event EventHandler OnDepoisAbreCupomVinculado;
        public event EventHandler OnDepoisCancelaCupom;
        public event EventHandler OnDepoisCancelaNaoFiscal;
        public event EventHandler OnDepoisFechaRelatorio;
        public event EventHandler OnDepoisLeituraX;
        public event EventHandler OnDepoisReducaoZ;
        public event EventHandler OnErrorSemPapel;

#if !COM_INTEROP

        public event EventHandler<AbreCupomEventArgs> OnAntesAbreCupom;
        public event EventHandler<AbreCupomEventArgs> OnAntesAbreNaoFiscal;
        public event EventHandler<RelatorioGerencialEventArgs> OnAntesAbreRelatorioGerencial;
        public event EventHandler<CancelaItemEventArgs> OnAntesCancelaItemNaoFiscal;
        public event EventHandler<CancelaItemEventArgs> OnAntesCancelaItemVendido;
        public event EventHandler<EfetuaPagamentoEventArgs> OnAntesEfetuaPagamento;
        public event EventHandler<EfetuaPagamentoEventArgs> OnAntesEfetuaPagamentoNaoFiscal;
        public event EventHandler<FechaCupomEventArgs> OnAntesFechaCupom;
        public event EventHandler<FechaCupomEventArgs> OnAntesFechaNaoFiscal;
        public event EventHandler<SangriaSuprimentoEventArgs> OnAntesSangria;
        public event EventHandler<SubtotalizaCupomEventArgs> OnAntesSubtotalizaCupom;
        public event EventHandler<SubtotalizaCupomEventArgs> OnAntesSubtotalizaNaoFiscal;
        public event EventHandler<SangriaSuprimentoEventArgs> OnAntesSuprimento;
        public event EventHandler<VendeItemEventArgs> OnAntesVendeItem;
        public event EventHandler<BobinaAdicionaLinhasEventArgs> OnBobinaAdicionaLinhas;
        public event EventHandler<ChangeEstadoEventArgs> OnChangeEstado;
        public event EventHandler<ChequeEstadoEventArgs> OnChequeEstado;
        public event EventHandler<AbreCupomEventArgs> OnDepoisAbreCupom;
        public event EventHandler<AbreCupomEventArgs> OnDepoisAbreNaoFiscal;
        public event EventHandler<RelatorioGerencialEventArgs> OnDepoisAbreRelatorioGerencial;
        public event EventHandler<CancelaItemEventArgs> OnDepoisCancelaItemNaoFiscal;
        public event EventHandler<CancelaItemEventArgs> OnDepoisCancelaItemVendido;
        public event EventHandler<EfetuaPagamentoEventArgs> OnDepoisEfetuaPagamento;
        public event EventHandler<EfetuaPagamentoEventArgs> OnDepoisEfetuaPagamentoNaoFiscal;
        public event EventHandler<FechaCupomEventArgs> OnDepoisFechaCupom;
        public event EventHandler<FechaCupomEventArgs> OnDepoisFechaNaoFiscal;
        public event EventHandler<SangriaSuprimentoEventArgs> OnDepoisSangria;
        public event EventHandler<SubtotalizaCupomEventArgs> OnDepoisSubtotalizaCupom;
        public event EventHandler<SubtotalizaCupomEventArgs> OnDepoisSubtotalizaNaoFiscal;
        public event EventHandler<SangriaSuprimentoEventArgs> OnDepoisSuprimento;
        public event EventHandler<VendeItemEventArgs> OnDepoisVendeItem;
        public event EventHandler<ErrorEventArgs> OnErrorAbreCupom;
        public event EventHandler<ErrorEventArgs> OnErrorAbreCupomVinculado;
        public event EventHandler<ErrorEventArgs> OnErrorAbreNaoFiscal;
        public event EventHandler<ErrorRelatorioEventArgs> OnErrorAbreRelatorioGerencial;
        public event EventHandler<ErrorEventArgs> OnErrorCancelaCupom;
        public event EventHandler<ErrorEventArgs> OnErrorCancelaItemNaoFiscal;
        public event EventHandler<ErrorEventArgs> OnErrorCancelaItemVendido;
        public event EventHandler<ErrorEventArgs> OnErrorCancelaNaoFiscal;
        public event EventHandler<ErrorEventArgs> OnErrorEfetuaPagamento;
        public event EventHandler<ErrorEventArgs> OnErrorEfetuaPagamentoNaoFiscal;
        public event EventHandler<ErrorEventArgs> OnErrorFechaCupom;
        public event EventHandler<ErrorEventArgs> OnErrorFechaNaoFiscal;
        public event EventHandler<ErrorEventArgs> OnErrorFechaRelatorio;
        public event EventHandler<ErrorEventArgs> OnErrorLeituraX;
        public event EventHandler<ErrorEventArgs> OnErrorReducaoZ;
        public event EventHandler<ErrorEventArgs> OnErrorSangria;
        public event EventHandler<ErrorEventArgs> OnErrorSubtotalizaCupom;
        public event EventHandler<ErrorEventArgs> OnErrorSubtotalizaNaoFiscal;
        public event EventHandler<ErrorEventArgs> OnErrorSuprimento;
        public event EventHandler<ErrorEventArgs> OnErrorVendeItem;
        public event EventHandler<MsgEventArgs> OnMsgAguarde;
        public event EventHandler<MsgRetentarEventArgs> OnMsgRetentar;
        public event EventHandler<PAFCalcEADEventArgs> OnPAFCalcEAD;
        public event EventHandler<ChaveEventArgs> OnPAFGetKeyRSA;

#else

		public event AbreCupomEventHandler OnAntesAbreCupom;
		public event AbreCupomEventHandler OnAntesAbreNaoFiscal;
		public event RelatorioGerencialEventHandler OnAntesAbreRelatorioGerencial;
		public event CancelaItemEventHandler OnAntesCancelaItemNaoFiscal;
		public event CancelaItemEventHandler OnAntesCancelaItemVendido;
		public event EfetuaPagamentoEventHandler OnAntesEfetuaPagamento;
		public event EfetuaPagamentoEventHandler OnAntesEfetuaPagamentoNaoFiscal;
		public event FechaCupomEventHandler OnAntesFechaCupom;
		public event FechaCupomEventHandler OnAntesFechaNaoFiscal;
		public event SangriaSuprimentoEventHandler OnAntesSangria;
		public event SubtotalizaCupomEventHandler OnAntesSubtotalizaCupom;
		public event SubtotalizaCupomEventHandler OnAntesSubtotalizaNaoFiscal;
		public event SangriaSuprimentoEventHandler OnAntesSuprimento;
		public event VendeItemEventHandler OnAntesVendeItem;
		public event BobinaAdicionaLinhasEventHandler OnBobinaAdicionaLinhas;
		public event ChangeEstadoEventHandler OnChangeEstado;
		public event ChequeEstadoEventHandler OnChequeEstado;
		public event AbreCupomEventHandler OnDepoisAbreCupom;
		public event AbreCupomEventHandler OnDepoisAbreNaoFiscal;
		public event RelatorioGerencialEventHandler OnDepoisAbreRelatorioGerencial;
		public event CancelaItemEventHandler OnDepoisCancelaItemNaoFiscal;
        public event CancelaItemEventHandler OnDepoisCancelaItemVendido;
		public event EfetuaPagamentoEventHandler OnDepoisEfetuaPagamento;
		public event EfetuaPagamentoEventHandler OnDepoisEfetuaPagamentoNaoFiscal;
		public event FechaCupomEventHandler OnDepoisFechaCupom;
		public event FechaCupomEventHandler OnDepoisFechaNaoFiscal;
        public event SangriaSuprimentoEventHandler OnDepoisSangria;
		public event SubtotalizaCupomEventHandler OnDepoisSubtotalizaCupom;
		public event SubtotalizaCupomEventHandler OnDepoisSubtotalizaNaoFiscal;
		public event SangriaSuprimentoEventHandler OnDepoisSuprimento;
		public event VendeItemEventHandler OnDepoisVendeItem;
		public event OnErrorEventHandler OnErrorAbreCupom;
		public event OnErrorEventHandler OnErrorAbreCupomVinculado;
		public event OnErrorEventHandler OnErrorAbreNaoFiscal;
		public event OnErrorRelatorioEventHandler OnErrorAbreRelatorioGerencial;
		public event OnErrorEventHandler OnErrorCancelaCupom;
		public event OnErrorEventHandler OnErrorCancelaItemNaoFiscal;
		public event OnErrorEventHandler OnErrorCancelaItemVendido;
		public event OnErrorEventHandler OnErrorCancelaNaoFiscal;
		public event OnErrorEventHandler OnErrorEfetuaPagamento;
		public event OnErrorEventHandler OnErrorEfetuaPagamentoNaoFiscal;
		public event OnErrorEventHandler OnErrorFechaCupom;
		public event OnErrorEventHandler OnErrorFechaNaoFiscal;
		public event OnErrorEventHandler OnErrorFechaRelatorio;
		public event OnErrorEventHandler OnErrorLeituraX;
		public event OnErrorEventHandler OnErrorReducaoZ;
		public event OnErrorEventHandler OnErrorSangria;
		public event OnErrorEventHandler OnErrorSubtotalizaCupom;
		public event OnErrorEventHandler OnErrorSubtotalizaNaoFiscal;
		public event OnErrorEventHandler OnErrorSuprimento;
		public event OnErrorEventHandler OnErrorVendeItem;
		public event OnMsgEventHandler OnMsgAguarde;
		public event OnMsgRetentarEventHandler OnMsgRetentar;
		public event OnPAFCalcEADEventHandler OnPAFCalcEAD;
		public event ChaveEventHandler OnPAFGetKeyRSA;
#endif

        #endregion Events

        #region Fields

        private Aliquota[] aliquotas;
        private FormaPagamento[] formasPagamento;
        private ComprovanteNaoFiscal[] comprovantesNaoFiscais;
        private RelatorioGerencial[] relatoriosGerenciais;
        private IECF ECF;

        #endregion Fields

        #region Constructor

        public ACBrECF() 
        {
            Modelo = ModeloECF.Nenhum;
        }

        #endregion Constructor

        #region Properties

        #region Visiveis

        [Category("Configutações ECF")]
        public ModeloECF Modelo { get; set; }

        //[Category("Configutações ECF")]
        //public ACBrDevice Device { get; private set; }

        [Category("Propriedades")]
        public int MaxLinhasBuffer { get; set; }
        [Category("Propriedades")]
        public bool DescricaoGrande { get; set; }
        [Category("Propriedades")]
        public bool GavetaSinalInvertido { get; set; }
        [Category("Propriedades")]
        public bool ArredondaPorQtd { get; set; }
        [Category("Propriedades")]
        public bool ArredondaItemMFD { get; set; }
        [Category("Propriedades")]
        public bool IgnorarTagsFormatacao { get; set; }
        [Category("Propriedades")]
        public int PausaRelatorio { get; set; }
        [Category("Propriedades")]
        public int PaginaDeCodigo { get; set; }
        [Category("Propriedades")]
        public string Sobre { get; set; }
        [Category("Propriedades")]
        public string ArqLOG { get; set; }
        [Category("Propriedades")]
        public string Operador { get; set; }
        [Category("Propriedades")]
        public string[] MemoParams { get; set; }
        [Category("Propriedades")]
        public int LinhasEntreCupons { get; set; }
        [Category("Propriedades")]
        public int DecimaisPreco { get; set; }
        [Category("Propriedades")]
        public int DecimaisQtd { get; set; }
        [Browsable(true)]
        [Category("Rodape")]
        public Rodape InfoRodapeCupom { get; private set; }
        [Browsable(true)]
        [Category("ConfigBarras")]
        public ConfigBarras ConfigBarras { get; private set; }

        #endregion Visiveis     

        #region Propriedades Não-visiveis

        [Browsable(false)]
        public bool Ativo { get; }

        [Browsable(false)]
        public DateTime DataHoraUltimaReducaoZ { get; }

        [Browsable(false)]
        public int Colunas { get; }        

        [Browsable(false)]
        public bool AguardandoResposta { get; }

        [Browsable(false)]
        public string ComandoLog { get; set; }

        [Browsable(false)]
        public bool AguardaImpressao { get; set; }

        [Browsable(false)]
        public string ModeloStr { get; }

        [Browsable(false)]
        public string RFDID { get; }

        [Browsable(false)]
        public DateTime DataHora { get; }

        [Browsable(false)]
        public string NumCupom { get; }

        [Browsable(false)]
        public string NumCOO { get; }

        [Browsable(false)]
        public string NumLoja { get; }

        [Browsable(false)]
        public string NumECF { get; }

        [Browsable(false)]
        public string NumSerie { get; }

        [Browsable(false)]
        public string NumSerieMFD { get; }

        [Browsable(false)]
        public string NumVersao { get; }

        [Browsable(false)]
        public DateTime DataMovimento { get; }

        [Browsable(false)]
        public DateTime DataHoraSB { get; }

        [Browsable(false)]
        public string CNPJ { get; }

        [Browsable(false)]
        public string IE { get; }

        [Browsable(false)]
        public string IM { get; }

        [Browsable(false)]
        public string Cliche { get; }

        [Browsable(false)]
        public string UsuarioAtual { get; }

        [Browsable(false)]
        public string SubModeloECF { get; }

        [Browsable(false)]
        public string PAF { get; }

        [Browsable(false)]
        public string NumCRZ { get; }

        [Browsable(false)]
        public string NumCRO { get; }

        [Browsable(false)]
        public string NumCCF { get; }

        [Browsable(false)]
        public string NumGNF { get; }

        [Browsable(false)]
        public string NumGRG { get; }

        [Browsable(false)]
        public string NumCDC { get; }

        [Browsable(false)]
        public string NumCOOInicial { get; }

        [Browsable(false)]
        public string ComandoEnviado { get; }

        [Browsable(false)]
        public string RespostaComando { get; }

        [Browsable(false)]
        public decimal VendaBruta
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal GrandeTotal
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalCancelamentos
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalDescontos
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalAcrescimos
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalTroco
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalSubstituicaoTributaria
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalNaoTributado
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalIsencao
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalCancelamentosISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalDescontosISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalAcrescimosISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalSubstituicaoTributariaISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalNaoTributadoISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalIsencaoISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalNaoFiscal
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public int NumUltItem { get; }

        [Browsable(false)]
        public bool PoucoPapel { get; }

        [Browsable(false)]
        public EstadoECF Estado { get; }

        [Browsable(false)]
        public bool HorarioVerao { get; }

        [Browsable(false)]
        public bool Arredonda { get; }

        [Browsable(false)]
        public bool Termica { get; }

        [Browsable(false)]
        public bool MFD { get; }

        [Browsable(false)]
        public string MFAdicional { get; }

        [Browsable(false)]
        public bool IdentificaConsumidorRodape { get; }

        [Browsable(false)]
        public bool ParamDescontoISSQN { get; }

        [Browsable(false)]
        public decimal SubTotal
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public decimal TotalPago
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
        }

        [Browsable(false)]
        public bool GavetaAberta { get; }

        [Browsable(false)]
        public bool ChequePronto { get; }

        [Browsable(false)]
        public int IntervaloAposComando { get; set; }

        [Browsable(false)]
        public Aliquota[] Aliquotas { get; }

        [Browsable(false)]
        public FormaPagamento[] FormasPagamento { get; }

        [Browsable(false)]
        public RelatorioGerencial[] RelatoriosGerenciais { get; }

        [Browsable(false)]
        public ComprovanteNaoFiscal[] ComprovantesNaoFiscais { get; }

        [Browsable(false)]
        public Consumidor Consumidor { get; private set; }

        [Browsable(false)]
        public DadosReducaoZClass DadosReducaoZClass { get; private set; }

        #endregion Propriedades Não-visiveis

        #endregion Properties

        #region Methods

        #region Métodos Ativar/Desativar

        public void Ativar()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.Ativar();
        }

        public void Desativar()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.Desativar();
        }

        #endregion Métodos Ativar/Desativar

        #region Métodos ECF

        public bool AcharECF(bool Modelo = true, bool Porta = true, int TimeOut = 3)
        {            
        }

        public bool AcharPorta(int TimeOut = 3)
        {
        }

        public bool EmLinha(int timeOut = 1)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.EmLinha(timeOut);
        }

        public void PulaLinhas(int numLinhas)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.PulaLinhas(numLinhas);
        }

        public void CortaPapel(bool corteParcial = false)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.CortaPapel(corteParcial);
        }

        public void CorrigeEstadoErro(bool reducaoZ = true)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.CorrigeEstadoErro(reducaoZ);
        }

        public void MudaHorarioVerao()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.MudaHorarioVerao();
        }

        public void MudaArredondamento(bool arredonda)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.MudaArredondamento(arredonda);
        }

        public void PreparaTEF()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.CarregaAliquotas();
            ECF.CarregaFormasPagamento();
            ECF.CarregaComprovantesNaoFiscais();
        }

        public void TestaPodeAbrirCupom()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.TestaPodeAbrirCupom();
        }

        public string EnviaComando(string cmd, int timeout = - 1)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.EnviaComando(cmd, timeout);
        }

        #endregion Métodos ECF

        #region Métodos Cheque

        public void ImprimeCheque(string Banco, [MarshalAs(UnmanagedType.Currency)] decimal Valor, 
            string Favorecido, string Cidade, DateTime Data, string Observacao = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.ImprimeCheque(Banco, Valor, Favorecido, Cidade, Data, Observacao);
        }

        public void CancelaImpressaoCheque()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.CancelaImpressaoCheque();
        }

        public string LeituraCMC7()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.LeituraCMC7();
        }

        #endregion Métodos Cheque

        #region Cupom Fiscal

        public void IdentificaConsumidor(string cpfCnpj, string nome, string endereco)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.IdentificaConsumidor(cpfCnpj, nome, endereco);
            Consumidor = new Consumidor();
            Consumidor.Atribuido = true;
            Consumidor.Documento = cpfCnpj;
            Consumidor.Nome = nome;
            Consumidor.Endereco = endereco;
            Consumidor.Enviado = true;
        }

        public void IdentificaOperador(string nome)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.IdentificaOperador(nome);
            Operador = nome;
        }

        public void AbreCupom(string cpfCnpj = "", string nome = "", string endereco = "", bool ModoPreVenda = false)
        {
            try
            {
                if (ECF == null)
                    throw new NullReferenceException("Escolha um modelo de ECF");

                if (OnAntesAbreCupom != null)
                    OnAntesAbreCupom.DynamicInvoke(this, new AbreCupomEventArgs(cpfCnpj, nome, endereco));

                ECF.AbreCupom(cpfCnpj, nome, endereco, ModoPreVenda);
                Consumidor = new Consumidor();
                Consumidor.Atribuido = true;
                Consumidor.Documento = cpfCnpj;
                Consumidor.Nome = nome;
                Consumidor.Endereco = endereco;
                Consumidor.Enviado = true;

                if (OnDepoisAbreCupom != null)
                    OnDepoisAbreCupom.DynamicInvoke(this, new AbreCupomEventArgs(cpfCnpj, nome, endereco));
            }
            catch (Exception ex)
            {
                if (OnErrorAbreCupom != null)
                {
                    var e = new ErrorEventArgs();
                    OnErrorAbreCupom.DynamicInvoke(this, e);
                    if (!e.Tratado)
                        throw ex;
                }
                else
                    throw ex;
            }
        }

        public void LegendaInmetroProximoItem()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.LegendaInmetroProximoItem();
        }

        public void VendeItem(string codigo, string descricao, string aliquotaICMS, 
            [MarshalAs(UnmanagedType.Currency)]decimal qtd, [MarshalAs(UnmanagedType.Currency)]decimal valorUnitario, 
            [MarshalAs(UnmanagedType.Currency)]decimal descontoPorc = 0M, string unidade = "UN", 
            string tipoDescontoAcrescimo = "%", string descontoAcrescimo = "D", int CodDepartamento = -1)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.VendeItem(codigo, descricao, aliquotaICMS, qtd, valorUnitario, 
                descontoPorc, unidade, tipoDescontoAcrescimo, descontoAcrescimo, CodDepartamento);
        }

        public void DescontoAcrescimoItemAnterior([MarshalAs(UnmanagedType.Currency)] decimal valorDesconto, 
            string descontoAcrescimo, string tipodescontoAcrescimo = "%", int item = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.DescontoAcrescimoItemAnterior(valorDesconto, descontoAcrescimo, tipodescontoAcrescimo, item);
        }

        public void SubtotalizaCupom([MarshalAs(UnmanagedType.Currency)] decimal descontoAcrescimo = 0M, string mensagemRodape = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.SubtotalizaCupom(descontoAcrescimo, mensagemRodape);
        }

        public void EfetuaPagamento(string codFormaPagto, [MarshalAs(UnmanagedType.Currency)] decimal valor, string observacao = "",
            bool imprimeVinculado = false)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.EfetuaPagamento(codFormaPagto, valor, observacao, imprimeVinculado);
        }

        public void EstornaPagamento(string codFormaPagtoEstornar, string codFormaPagtoEfetivar, double valor, string observacao)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.EstornaPagamento(codFormaPagtoEstornar, codFormaPagtoEfetivar, valor, observacao);
        }

        public void FechaCupom(string observacao = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.FechaCupom(observacao);
            Consumidor = new Consumidor();
        }

        public void CancelaCupom()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.CancelaCupom();
            Consumidor = new Consumidor();
        }

        public void CancelaItemVendido(int numItem)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.CancelaItemVendido(numItem);
        }

        public void CancelaItemVendidoParcial(int numItem, [MarshalAs(UnmanagedType.Currency)] decimal quantidade)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.CancelaItemVendidoParcial(numItem, quantidade);
        }

        public void CancelaDescontoAcrescimoItem(int numItem)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.CancelaDescontoAcrescimoItem(numItem);
        }

        public void CancelaDescontoAcrescimoSubTotal(string tipoAcrescimoDesconto)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.CancelaDescontoAcrescimoSubTotal(tipoAcrescimoDesconto);
        }

        #endregion Cupom Fiscal

        #region Métodos DAV

        public void DAV_Abrir(DateTime emissao, string decrdocumento, string numero, string situacao, string vendedor, 
            string observacao, string cpfCnpj, string nome, string endereco, int indice = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.DAV_Abrir(emissao, decrdocumento, numero, situacao, vendedor, observacao, cpfCnpj, nome, endereco, indice);
        }

        public void DAV_RegistrarItem(string codigo, string descricao, string unidade, double quantidade, 
            double vlrunitario, double desconto, double acrescimo, bool cancelado)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.DAV_RegistrarItem(codigo, descricao, unidade, quantidade, vlrunitario, desconto, acrescimo, cancelado);
        }

        public void DAV_Fechar(string observacao)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.DAV_Fechar(observacao);
        }

#if COM_INTEROP

		public void PafMF_RelDAVEmitidos(ref DAVs[] DAVs, string TituloRelatorio, int IndiceRelatorio)
#else

        public void PafMF_RelDAVEmitidos(DAVs[] DAVs, string TituloRelatorio, int IndiceRelatorio)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.PafMF_RelDAVEmitidos(DAVs, TituloRelatorio, IndiceRelatorio);
        }

        #endregion Métodos DAV

        #region PAF Relatorios

#if COM_INTEROP

		public void PafMF_RelMeiosPagamento(ref FormaPagamento[] formasPagamento, string TituloRelatorio, int indiceRelatorio)
#else

        public void PafMF_RelMeiosPagamento(FormaPagamento[] formasPagamento, string TituloRelatorio, int indiceRelatorio)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.PafMF_RelMeiosPagamento(formasPagamento, TituloRelatorio, indiceRelatorio);
        }

        public void PafMF_RelIdentificacaoPafECF(IdenticacaoPaf identificacaoPAF = null, int indiceRelatorio = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.PafMF_RelIdentificacaoPafECF(identificacaoPAF, indiceRelatorio);
        }

        public void PafMF_RelParametrosConfiguracao(InfoPaf infoPAF = null, int indiceRelatorio = 1)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.PafMF_RelParametrosConfiguracao(infoPAF, indiceRelatorio);
        }

        #endregion PAF Relatorios

        #region PAF

        public void PafMF_GerarCAT52(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");

            ECF.PafMF_GerarCAT52(DataInicial, DataFinal, CaminhoArquivo);
        }

        public void PafMF_LX_Impressao()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void ArquivoMFD_DLL(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo, FinalizaArqMFD Finaliza = FinalizaArqMFD.MFD, params TipoDocumento[] Documentos)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void ArquivoMFD_DLL(int COOInicial, int COOFinal, string CaminhoArquivo, FinalizaArqMFD Finaliza = FinalizaArqMFD.MFD, TipoContador TipoContador = TipoContador.COO, params TipoDocumento[] Documentos)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void DoAtualizarValorGT()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void DoVerificaValorGT()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void PafMF_Binario(string pathArquivo)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion PAF

        #region PAF LMFC

#if COM_INTEROP

		public void PafMF_LMFC_Cotepe1704PorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#else

        public void PafMF_LMFC_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_LMFC_Cotepe1704PorCRZ(int CRZInicial, int CRZFinal, string CaminhoArquivo)
#else

        public void PafMF_LMFC_Cotepe1704(int CRZInicial, int CRZFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_LMFC_EspelhoPorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#else

        public void PafMF_LMFC_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_LMFC_EspelhoPorCRZ(int CRZInicial, int CRZFinal, string CaminhoArquivo)
#else

        public void PafMF_LMFC_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_LMFC_ImpressaoPorData(DateTime DataInicial, DateTime DataFinal)
#else

        public void PafMF_LMFC_Impressao(DateTime DataInicial, DateTime DataFinal)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_LMFC_ImpressaoPorCRZ(int CRZInicial, int CRZFinal)
#else

        public void PafMF_LMFC_Impressao(int CRZInicial, int CRZFinal)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion PAF LMFC

        #region PAF LMFS

#if COM_INTEROP

		public void PafMF_LMFS_EspelhoPorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#else

        public void PafMF_LMFS_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_LMFS_EspelhoPorCRZ(int CRZInicial, int CRZFinal, string CaminhoArquivo)
#else

        public void PafMF_LMFS_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_LMFS_ImpressaoPorData(DateTime DataInicial, DateTime DataFinal)
#else

        public void PafMF_LMFS_Impressao(DateTime DataInicial, DateTime DataFinal)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_LMFS_ImpressaoPorCRZ(int CRZInicial, int CRZFinal)
#else

        public void PafMF_LMFS_Impressao(int CRZInicial, int CRZFinal)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion PAF LMFS

        #region PAF Espelho MFD

#if COM_INTEROP

		public void PafMF_MFD_Cotepe1704PorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#else

        public void PafMF_MFD_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_MFD_Cotepe1704PorCOO(int COOInicial, int COOFinal, string CaminhoArquivo)
#else

        public void PafMF_MFD_Cotepe1704(int COOInicial, int COOFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion PAF Espelho MFD

        #region PAF Arq. MFD

#if COM_INTEROP

		public void PafMF_MFD_EspelhoPorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#else

        public void PafMF_MFD_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void PafMF_MFD_EspelhoPorCOO(int COOInicial, int COOFinal, string CaminhoArquivo)
#else

        public void PafMF_MFD_Espelho(int COOInicial, int COOFinal, string CaminhoArquivo)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion PAF Arq. MFD

        #region Leitura Memoria Fiscal

#if COM_INTEROP

		public void LeituraMemoriaFiscalPorCRZ(int reducaoInicial, int reducaoFinal, bool simplificada = false)
#else

        public void LeituraMemoriaFiscal(int reducaoInicial, int reducaoFinal, bool simplificada = false)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void LeituraMemoriaFiscalPorData(DateTime dataInicial, DateTime dataFinal, bool simplificada = false)
#else

        public void LeituraMemoriaFiscal(DateTime dataInicial, DateTime dataFinal, bool simplificada = false)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public string LeituraMemoriaFiscalSerialPorCRZ(int reducaoInicial, int reducaoFinal, bool simplificada = false)
#else

        public string LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, bool simplificada = false)
#endif
        {
            const int LEN = 10 * 1024;
            StringBuilder buffer = new StringBuilder(LEN);

            int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalSerialReducao(this.Handle, reducaoInicial, reducaoFinal, simplificada, buffer, LEN);
            CheckResult(ret);

            buffer.Length = ret;
            return FromUTF8(buffer);
        }

#if COM_INTEROP

		public string LeituraMemoriaFiscalSerialPorData(DateTime dataInicial, DateTime dataFinal, bool simplificada = false)
#else

        public string LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, bool simplificada = false)
#endif
        {
            const int LEN = 10 * 1024;
            StringBuilder buffer = new StringBuilder(LEN);

            int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalSerialData(this.Handle, dataInicial.ToOADate(), dataFinal.ToOADate(), simplificada, buffer, LEN);
            CheckResult(ret);

            buffer.Length = ret;
            return FromUTF8(buffer);
        }

#if COM_INTEROP

		public void LeituraMemoriaFiscalSerialPorCRZ(int reducaoInicial, int reducaoFinal, string nomeArquivo, bool simplificada = false)
#else

        public void LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, string nomeArquivo, bool simplificada = false)
#endif
        {
            int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalArquivoReducao(this.Handle, reducaoInicial, reducaoFinal, ToUTF8(nomeArquivo), simplificada);
            CheckResult(ret);
        }

#if COM_INTEROP

		public void LeituraMemoriaFiscalSerialPorData(DateTime dataInicial, DateTime dataFinal, string nomeArquivo, bool simplificada = false)
#else

        public void LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, string nomeArquivo, bool simplificada = false)
#endif
        {
            int ret = ACBrECFInterop.ECF_LeituraMemoriaFiscalArquivoData(this.Handle, dataInicial.ToOADate(), dataFinal.ToOADate(), ToUTF8(nomeArquivo), simplificada);
            CheckResult(ret);
        }

        #endregion Leitura Memoria Fiscal

        #region Cupom Vinculado

#if !COM_INTEROP

        public void AbreCupomVinculado(int coo, string codFormaPagto, decimal valor)
        {
            var cooStr = string.Format("{0:000000}", coo);
            AbreCupomVinculado(cooStr, codFormaPagto, valor);
        }

#endif

        public void AbreCupomVinculado(string coo, string codFormaPagto, [MarshalAs(UnmanagedType.Currency)] decimal valor)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if COM_INTEROP

		public void AbreCupomVinculadoCNF(string coo, string codFormaPagto, string codComprovanteNaoFiscal, [MarshalAs(UnmanagedType.Currency)] decimal valor)
#else

        public void AbreCupomVinculado(string coo, string codFormaPagto, string codComprovanteNaoFiscal, decimal valor)
#endif
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

#if !COM_INTEROP

        public void LinhaCupomVinculado(string[] linhas)
        {
            foreach (string linha in linhas)
                LinhaCupomVinculado(linha);
        }

#endif

        public void LinhaCupomVinculado(string linha)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void ReimpressaoVinculado()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void SegundaViaVinculado()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion Cupom Vinculado

        #region Leitura X / Redução Z

        public void LeituraX()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void ReducaoZ([Optional]DateTime data)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #region COM_INTEROP

#if COM_INTEROP

		[ComVisible(false)]
#endif

        #endregion COM_INTEROP

        public string DadosUltimaReducaoZ()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public string DadosReducaoZ()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion Leitura X / Redução Z

        #region Relatório Gerencial

        public void AbreRelatorioGerencial(int indice = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #region COM_INTEROP

#if COM_INTEROP

		[ComVisible(false)]
#endif

        #endregion COM_INTEROP

        public void LinhaRelatorioGerencial(string[] linhas, int indiceBMP = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void LinhaRelatorioGerencial(string linha, int indiceBMP = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void ProgramaRelatoriosGerenciais(string descricao, string posicao = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void CarregaRelatoriosGerenciais()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void LerTotaisRelatoriosGerenciais()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }        

        #region COM_INTEROP

#if COM_INTEROP

		[ComVisible(false)]
#endif

        #endregion COM_INTEROP

        public void RelatorioGerencial(List<string> relatorio, int vias = 1, int indice = 0)
        {
            RelatorioGerencial(relatorio.ToArray(), vias, indice);
        }

        #region COM_INTEROP

#if COM_INTEROP

		[ComVisible(false)]
#endif

        #endregion COM_INTEROP

        public void RelatorioGerencial(IEnumerable<string> relatorio, int vias = 1, int indice = 0)
        {
            RelatorioGerencial(relatorio.ToArray(), vias, indice);
        }

        public void RelatorioGerencial(string[] relatorio, int vias = 1, int indice = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void FechaRelatorio()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion Relatório Gerencial

        #region Alíquotas

        public void CarregaAliquotas()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void LerTotaisAliquota()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void ProgramaAliquota([MarshalAs(UnmanagedType.Currency)] decimal aliquota, string tipo, string posicao = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion Alíquotas

        #region Formas de Pagto

        public FormaPagamento AchaFPGDescricao(string descricao, bool buscaExata = true, bool ignoreCase = true)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public FormaPagamento AchaFPGIndice(string indice)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void CarregaFormasPagamento()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void LerTotaisFormaPagamento()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void ProgramaFormaPagamento(string descricao, bool permiteVinculado, string posicao = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion Formas de Pagto

        #region Comprovantes Não Fiscal

        public ComprovanteNaoFiscal AchaCNFDescricao(string descricao, bool buscaExata = true, bool ignoreCase = true)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void CarregaComprovantesNaoFiscais()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void LerTotaisComprovanteNaoFiscal()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void ProgramaComprovanteNaoFiscal(string descricao, string tipo, string posicao = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void AbreNaoFiscal(string cpfCnpj = "", string nome = "", string endereco = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void RegistraItemNaoFiscal(string codCNF, [MarshalAs(UnmanagedType.Currency)] decimal value, string obs = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void SubtotalizaNaoFiscal([MarshalAs(UnmanagedType.Currency)] decimal descontoAcrescimo, string mensagemRodape = "")
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void EfetuaPagamentoNaoFiscal(string codFormaPagto, [MarshalAs(UnmanagedType.Currency)] decimal valor, string observacao = "", bool imprimeVinculado = false)
        {
            i if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void FechaNaoFiscal(string observacao = "", int IndiceBMP = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void CancelaNaoFiscal()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion Comprovantes Não Fiscal

        #region Suprimento e Sangria

        public void Suprimento([MarshalAs(UnmanagedType.Currency)] decimal valor, string obs, string DescricaoCNF = "SUPRIMENTO", string DescricaoFPG = "DINHEIRO", int indicebmp = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        public void Sangria([MarshalAs(UnmanagedType.Currency)] decimal valor, string obs, string DescricaoCNF = "SANGRIA", string DescricaoFPG = "DINHEIRO", int indicebmp = 0)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion Suprimento e Sangria

        #region Gaveta

        public void AbreGaveta()
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion Gaveta

        #region Programação

        public void IdentificaPAF(string nomeVersao, string md5)
        {
            if (ECF == null)
                throw new NullReferenceException("Escolha um modelo de ECF");
        }

        #endregion Programação

        #region Override Methods

        protected internal override void OnInitialize()
        {
            InfoRodapeCupom = new Rodape();
            ConfigBarras = new ConfigBarras();
            Consumidor = new Consumidor();
            DadosReducaoZClass = new DadosReducaoZClass();
        }

        protected override void OnDisposing()
        {
        }

        #endregion Override Methods

        #endregion Methods
    }
}
