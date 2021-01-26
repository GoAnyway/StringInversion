using System;

namespace StringInversionWPF.ImportedFunctions.Custom
{
    public static class DllWrapper
    {
        static DllWrapper()
        {
            var isX86 = IsSystemX86();
            ImportedFunctions = new CustomFunctions(isX86);
        }

        public static CustomFunctions ImportedFunctions { get; set; }

        private static bool IsSystemX86() => IntPtr.Size == 4;
    }
}