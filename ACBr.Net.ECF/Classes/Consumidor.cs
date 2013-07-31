namespace ACBr.Net.ECF
{
	public sealed class Consumidor 
	{
		#region Properties

        public string Documento { get; set; }
		public string Nome { get; set; }
        public string Endereco { get; set; }
        public bool Atribuido { get; set; }
        public bool Enviado { get; set; }

		#endregion Properties
	}
}