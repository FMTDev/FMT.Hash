using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMT.Hash
{
    public static class Fnv64
    {
        /// <summary>
        /// https://github.com/electronicarts/EAStdC/blob/master/source/EAHashString.cpp
        /// </summary>
        /// <returns></returns>
        public static UInt64 FNV64_String8_Lower(string charArray)
        {
            ulong initial_value = 14695981039346656037;
            ulong FNV_PRIME = 1099511628211;

            foreach (var c in charArray.ToLower().Select(x => (byte)x))
                initial_value = (initial_value * FNV_PRIME) ^ c;

            return initial_value;
        }

        /// <summary>
        /// https://github.com/electronicarts/EAStdC/blob/master/source/EAHashString.cpp
        /// </summary>
        /// <returns></returns>
        public static UInt64 FNV64_String16_Lower(string charArray)
        {
            ulong initial_value = 14695981039346656037;
            ulong FNV_PRIME = 1099511628211;

            foreach (var c in charArray.ToLower().Select(x => (byte)x))
                initial_value = (initial_value * FNV_PRIME) ^ c;

            return initial_value;
        }

        /// <summary>
        /// https://github.com/electronicarts/EAStdC/blob/master/source/EAHashString.cpp
        /// </summary>
        /// <returns></returns>
        public static UInt64 FNV64_String32_Lower(string charArray)
        {
            ulong initial_value = 14695981039346656037;
            ulong FNV_PRIME = 1099511628211;

            foreach (var c in charArray.ToLower().Select(x => (byte)x))
                initial_value = (initial_value * FNV_PRIME) ^ c;

            return initial_value;
        }
    }
}
