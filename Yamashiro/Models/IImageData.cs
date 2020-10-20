using System;
using System.Collections.Generic;
using System.Text;
using Yamashiro.Utility;

namespace Yamashiro.Models
{
    public interface IImageData
    {
        public string RawData { get; set; }
        public CDNExtension FileType { get; }
        public string Base64File { get; }
    }
}
