using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FMT.Hash
{
    /// <summary>
    /// Sha256 32bit (uint) implementation of Frostbite Hashing used extensively during its TypeInfo/FieldInfo hash stage
    /// </summary>
    public static class Sha256
    {
        /// <summary>
        /// Sha256 32bit (uint) implementation of Frostbite Hashing used extensively during its TypeInfo/FieldInfo hash stage
        /// !!!NOT COMPLETE!!!
        /// </summary>
        /// <param name="strVal"></param>
        /// <param name="strSeed"></param>
        /// <returns></returns>
        public static uint SHA256Hash32_Lowercase_RT(string strVal, string strSeed = "5381")
        {
            // seed is 5381 or 1029

            ArgumentNullException.ThrowIfNullOrEmpty(strVal);
            ArgumentNullException.ThrowIfNullOrEmpty(strSeed);

            var buf = new byte[512];

            var sha256Context = SHA256.Create();

            // Lower the input value;
            strVal = strVal.ToLower();
            // Lower the input value;
            strSeed = strSeed.ToLower();

            // Length is the strVal
            var lenVal = strVal.Length;
            buf = Resize(buf, lenVal + 1); // +1 for the \0 terminator. probably not actually required...

            // Hash the buffer data once against the buf
            buf = sha256Context.ComputeHash(buf, 0, 1 * lenVal);

            // Hash the buffer data again against the buf[0] size * strSeed.Length
            var lenSeed = strSeed.Length;
            buf = Resize(buf, lenSeed);
            buf = sha256Context.ComputeHash(buf, 0, 1 * lenSeed);

            // Finalize the compute
            uint hashVal = (uint)BitConverter.ToUInt64(buf);

            // Return the hash as a BigEndian hashed value + 28
            return ToBigEndian((hashVal + 28));
        }

        private static uint ToBigEndian(uint littleEndian)
        {
            var spanage = new Span<byte>(new byte[4]);
            var bytesOfLittleEndian = BitConverter.TryWriteBytes(spanage, littleEndian);
            spanage.Reverse();
            return BitConverter.ToUInt32(spanage);
        }

        private static byte[] Resize(byte[] bytes, int length)
        {
            var buf = new byte[length];
            for (var iBufSize = 0; iBufSize < length && iBufSize < bytes.Length; iBufSize++)
                buf[iBufSize] = bytes[iBufSize];

            return buf;
        }
        //{
        //	using fixed_string_buf = eastl::fixed_string<char, 512>;
        //	fixed_string_buf buf;

        //    EA::Crypto::SHA2::SHA256Context context;

        //    EA::Crypto::SHA2::SHA256Initialize(&context);

        //	// do the 1st part
        //	const fixed_string_buf::size_type lenVal = static_cast<fixed_string_buf::size_type>(strlen(strVal));
        //    buf.resize(lenVal + 1); // +1 for the \0 terminator. probably not actually required...
        //	for (fixed_string_buf::size_type i = 0; i != lenVal; ++i)
        //		buf[i] = static_cast<char>(tolower(strVal[i]));

        //	EA::Crypto::SHA2::SHA256Update(&context, reinterpret_cast<const uint8_t*>(buf.data()), sizeof(buf[0])* lenVal);

        //	// do the 2nd part
        //	fixed_string_buf::size_type lenSeed = static_cast<fixed_string_buf::size_type>(strlen(strSeed));
        //    buf.resize(lenSeed + 1);
        //	for (fixed_string_buf::size_type i = 0; i != lenSeed; ++i)
        //		buf[i] = static_cast<char>(tolower(strSeed[i]));

        //	EA::Crypto::SHA2::SHA256Update(&context, reinterpret_cast<const uint8_t*>(buf.data()), sizeof(buf[0])* lenSeed);

        //	// compute final hash
        //	uint8_t hashVal[EA::Crypto::SHA2::kHashSize256] = { 0 };
        //    SHA256Finalize(&context, hashVal);

        //    // extract the relevant part
        //    const uint32_t result = EA::StdC::ToBigEndian(*((uint32_t*)((char*)hashVal + 28)));

        //	return result;
        //}
    }
}
