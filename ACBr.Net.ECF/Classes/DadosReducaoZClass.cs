using System;
using ACBr.Net.Core.ECF;

namespace ACBr.Net.ECF
{
	public sealed class DadosReducaoZClass
	{
		#region Fields

		private ComprovanteNaoFiscal[] comprovantesNaoFiscais;
		private Aliquota[] icms;
		private RelatorioGerencial[] relatoriosGerenciais;
		private Aliquota[] issqn;
		private FormaPagamento[] formasPagamento;

		#endregion Fields

		#region Propriedades

        public int COO { get; internal set; }

        public int CFD { get; internal set; }

        public decimal CancelamentoISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public int GNFC { get; internal set; }

        public int CRO { get; internal set; }

        public decimal ValorVendaBruta
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

		public ComprovanteNaoFiscal[] TotalizadoresNaoFiscais
		{
			get
			{
				return comprovantesNaoFiscais;
			}
		}

		public Aliquota[] ICMS
		{
			get
			{
				return this.icms;
			}
		}

        public decimal AcrescimoICMS
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal DescontoICMS
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal NaoTributadoICMS
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

		public RelatorioGerencial[] RelatorioGerencial
		{
			get
			{
				return relatoriosGerenciais;
			}
		}

        public int CRZ { get; internal set; }

		public Aliquota[] ISSQN
		{
			get
			{
				return issqn;
			}
		}

        public int GRG { get; internal set; }

        public decimal ValorGrandeTotal
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal AcrescimoISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal NaoTributadoISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal IsentoICMS
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal SubstituicaoTributariaICMS
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public DateTime DataDaImpressora
        {
            get;
            internal set;
        }

        public decimal TotalOperacaoNaoFiscal
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal DescontoISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal CancelamentoOPNF
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal AcrescimoOPNF
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal DescontoOPNF
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal CancelamentoICMS
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public int GNF { get; internal set; }

        public decimal IsentoISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal SubstituicaoTributariaISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal VendaLiquida
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public int CFC { get; internal set; }

        public int CCF { get; internal set; }

        public decimal TotalISSQN
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public decimal TotalICMS
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

        public int CDC { get; internal set; }

        public int CCDC { get; internal set; }

        public int NCN { get; internal set; }

        public DateTime DataDoMovimento { get; internal set; }

		public FormaPagamento[] MeiosDePagamento
		{
			get
			{
				return this.formasPagamento;
			}
		}

        public string NumeroCOOInicial { get; internal set; }

        public string NumeroDoECF { get; internal set; }

        public string NumeroDeSerie { get; internal set; }

        public string NumeroDeSerieMFD { get; internal set; }

        public string NumeroDaLoja { get; internal set; }

        public decimal TotalTroco
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP

            get;
            internal set;
        }

		#endregion Propriedades

		#region Methods

		public void CalculaValoresVirtuais()
		{			
		}

		public string MontaDadosReducaoZ()
		{			
		}

		#endregion Methods
	}
}