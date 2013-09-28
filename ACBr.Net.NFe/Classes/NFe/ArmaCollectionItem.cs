using System;
using System.Collections.Generic;

namespace ACBr.Net.NFe
{
    [Serializable]
    public sealed class ArmaCollectionItem
    {
        #region Constructor

        internal ArmaCollectionItem()
        {

        }

        #endregion Constructor

        #region Propriedades

        public TipoArma TpArma { get; set; }

        public string NSerie { get; set; }

        public string NCano { get; set; }

        public string Descr { get; set; }

        #endregion Propriedades
    }
}
