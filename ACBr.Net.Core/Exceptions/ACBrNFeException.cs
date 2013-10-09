using System;
using System.Runtime.Serialization;

namespace ACBr.Net.Core
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("A990AE3E-B703-4E4B-9EAF-55A76BD0D616")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
    public class ACBrNFeException : Exception
    {
        public ACBrNFeException(string message)
            : base(message)
        {
        }

        public ACBrNFeException()
        {

        }

        public ACBrNFeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected ACBrNFeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

    }
}

namespace ACBr.Net.Core
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("6D293F77-4569-477E-BC62-E5339F661BDD")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
}
