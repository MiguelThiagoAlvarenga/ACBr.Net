using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
	public sealed class NotasFiscais : IEnumerable<NotaFiscal>
	{
		#region Fields        

        List<NotaFiscal> list;

		#endregion Fields

		#region Constructor

        public NotasFiscais()
        {
            list = new List<NotaFiscal>();
        }

		#endregion Constructor

		#region Properties

        public string GetNamePath { get; set; }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public NotaFiscal this[int idx]
        {
            get
            {
                if (idx >= Count || idx < 0)
                    throw new IndexOutOfRangeException();

                return list[idx];
            }
            set
            {
                if (idx >= Count || idx < 0)
                    throw new IndexOutOfRangeException();

                list[idx] = value;
            }
        }

		#endregion Properties

		#region Methods		

		public NotaFiscal AddNew()
		{
			var nf = new NotaFiscal();
            list.Add(nf);
            return nf;
		}

        public void Add(NotaFiscal value)
        {
            list.Add(value);
        }

        public void AddRange(IEnumerable<NotaFiscal> value)
        {
            list.AddRange(value);
        }

        public void Clear()
        {
            list.Clear();
        }

        public void GerarNFe()
        {
        }        

		public void Assinar()
		{
			
		}

		public void Valida()
		{
			
		}

		public void ValidaAssinatura(out string MSG)
		{
            MSG = "Teste";
		}

		public void Imprimir()
        {
            foreach(var nf in list.AsEnumerable())
            {
                nf.Imprimir();
            }
            
        }

		public void ImprimirPDF()
		{
            foreach (var nf in list.AsEnumerable())
            {
                nf.ImprimirPDF();
            }
		}

		public bool LoadFromFile(string arquivo)
		{
            return true;
		}

        public bool LoadFromStream(Stream arquivo)
        {
            return true;
        }

		public bool LoadFromString(string xml)
        {
            return true;
		}

		public bool SaveToFile(string arquivo, bool txt = false)
		{
            return true;
		}

		public bool SaveToTXT(string arquivo)
        {
            return true;
		}

		#endregion Methods

		#region IEnumerable<NotasFiscai>

		public IEnumerator<NotaFiscal> GetEnumerator()
		{
            return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable<NotasFiscais>
	}
}
