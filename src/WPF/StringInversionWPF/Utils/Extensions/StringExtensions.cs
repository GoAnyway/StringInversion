using StringInversionWPF.ImportedFunctions.Custom;

namespace StringInversionWPF.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string Inverse(this string source) =>
            DllWrapper.ImportedFunctions.InverseString(source);
    }
}