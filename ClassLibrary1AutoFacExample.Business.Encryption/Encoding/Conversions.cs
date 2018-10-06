using System;
using System.Text;

namespace AutoFacExample.Business.Encryption.Encoding
{
    public class Conversions : IConversions
    {
        public string HexToDecimalConversion8(string data)
        {
            byte[] bytes = new byte[data.Length];
            int pos = 2;
            long decimalValue = 0;
            string decimalValueOutput = "";
            string tempValue = "";

            for (int i = 0; i < bytes.Length; i += 1)
            {
                bytes[i] = (Convert.ToByte(data.Substring(i, 1), 16));
                decimalValue += bytes[i] * Convert.ToInt64(Math.Pow(16, (pos - 1 - i % pos)));
                if (i % pos == pos - 1)
                {
                    tempValue += decimalValue;
                    decimalValueOutput += tempValue.PadLeft(pos + 2, '0') + " ";
                    tempValue = "";
                    decimalValue = 0;
                }
            }
            return decimalValueOutput;
        }

        public string HexToStringConversion8(string data)
        {
            int ValuesLength = data.Length;
            byte[] bytes = new byte[ValuesLength / 2];
            int pos = 0;
            //for (int i = ValuesLength - 2; i >= 0; i -= 2)
            for (int i = 0; i < ValuesLength; i += 2)
            {

                bytes[pos] = Convert.ToByte(data.Substring(i, 2), 16);
                pos++;
            }            
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public string StringToHexConversion8(string data)
        {
            byte[] values = System.Text.Encoding.UTF8.GetBytes(data);
            StringBuilder sb = new StringBuilder(values.Length * 2);
            for (int i = 0; i < values.Length; i++)
            {
                sb.AppendFormat("{0:X2}", values[i]);

            }            
            return sb.ToString();
        }
    }
}
