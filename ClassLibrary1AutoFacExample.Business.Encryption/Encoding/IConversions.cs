using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacExample.Business.Encryption.Encoding
{
    public interface IConversions
    {
        string StringToHexConversion8(string data);
        string HexToStringConversion8(string data);
        string HexToDecimalConversion8(string data);
    }
}
