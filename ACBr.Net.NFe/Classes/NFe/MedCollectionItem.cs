using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
    public sealed class MedCollectionItem
    {
        #region Constructor

        internal MedCollectionItem()
        {

        }

        #endregion Constructor

        #region Propriedades

        public string NLote { get; set; }

        public decimal QLote { get; set; }

        public decimal VPMC { get; set; }

        public DateTime DFab { get; set; }

        public DateTime DVal { get; set; }

        #endregion Propriedades
    }
}