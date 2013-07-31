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
	[Guid("C5C65122-FB1C-427F-89AD-5E1D20CB0420")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class InfoPaf
	{
		#region Constructor

		public InfoPaf()
		{
		}

		#endregion Constructor

		#region Properties

		#region Dados do Aplicativo

        public string NomeAplicativo { get; set; }

        public string LinguagemAplicativo { get; set; }

        public string BancoDeDadosAplicativo { get; set; }

        public string SistemaOperacionalAplicativo { get; set; }

        public string VersaoAplicativo { get; set; }

        public string PrincipalExeAplicativo { get; set; }

        public string MD5Aplicativo { get; set; }

		#endregion Dados do Aplicativo

		#region Dados de Funcionalidades

        public TipoFuncionamento TipoFuncionamento { get; set; }

        public TipoIntegracao TipoIntegracao { get; set; }

        public TipoDesenvolvimento TipoDesenvolvimento { get; set; }

		#endregion Dados de Funcionalidades

		#region Dados de Nao Concomitancia

        public bool RealizaPreVenda { get; set; }

        public bool RealizaDAVECF { get; set; }

        public bool RealizaDAVNaoFiscal { get; set; }

        public bool RealizaDAVOS { get; set; }

        public bool RealizaLancamentoMesa { get; set; }

        public bool RealizaDAVConfAnexoII { get; set; }

		#endregion Dados de Nao Concomitancia

		#region Dados de Aplicacoes Especiais

        public bool IndiceTecnicoProducao { get; set; }

        public bool BarSimiliarECFRestaurante { get; set; }

        public bool BarSimiliarECFComum { get; set; }

        public bool BarSimiliarBalanca { get; set; }

        public bool UsaImpressoraNaoFiscal { get; set; }

        public bool DAVDiscrFormula { get; set; }

		#endregion Dados de Aplicacoes Especiais

		#region Dados Criterios UF

        public bool TotalizaValoresLista { get; set; }

        public bool TransPreVenda { get; set; }

        public bool TransDAV { get; set; }

        public bool RecompoeGT { get; set; }

        public bool RecompoeNumSerie { get; set; }

        public bool EmitePED { get; set; }

        public bool CupomMania { get; set; }

        public bool MinasLegal { get; set; }

        public bool ParaibaLegal { get; set; }

        public bool NotaLegalDF { get; set; }

        public bool TrocoEmCartao { get; set; }

		#endregion Dados Criterios UF

		#region Posto Combustiveis

        public bool AcumulaVolumeDiario { get; set; }

        public bool ArmazenaEncerranteIniFinal { get; set; }

        public bool CadastroPlacaBomba { get; set; }

        public bool EmiteContrEncerrAposREDZLEIX { get; set; }

        public bool ImpedeVendaVlrZero { get; set; }

        public bool IntegradoComBombas { get; set; }

        public bool CriaAbastDivergEncerrante { get; set; }

		#endregion Posto Combustiveis

		#region Transporte Passageiros

        public bool TransportePassageiro { get; set; }

		#endregion Transporte Passageiros

		#endregion Properties
	}
}