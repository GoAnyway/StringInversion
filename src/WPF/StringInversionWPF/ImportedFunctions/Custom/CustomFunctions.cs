using System.Runtime.InteropServices;
using System.Text;

namespace StringInversionWPF.ImportedFunctions.Custom
{
    public class CustomFunctions
    {
        private readonly bool _isX86;

        public CustomFunctions(bool isX86)
        {
            _isX86 = isX86;
        }

        [DllImport("StringInversion32.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int InverseString32(byte[] buffer);

        [DllImport("StringInversion64.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int InverseString64(byte[] buffer);

        public string InverseString(string stringToInverse)
        {
            var buffer = Encoding.GetEncoding(1251).GetBytes(stringToInverse);

            var code = _isX86
                ? InverseString32(buffer)
                : InverseString64(buffer);

            return Encoding.GetEncoding(1251).GetString(buffer).Replace("\0", string.Empty);
        }
    }
}