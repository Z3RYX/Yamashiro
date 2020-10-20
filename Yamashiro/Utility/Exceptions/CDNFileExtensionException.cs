using System;
using System.Collections.Generic;
using System.Text;

namespace Yamashiro.Utility.Exceptions
{
    internal class CDNFileExtensionException : Exception
    {
        internal CDNFileExtensionException(CDNExtension EXT) : base("Endpoint does not support file extension " + EXT.ToString()) { }
    }
}
