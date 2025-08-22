using System.Collections.Generic;
using System.Diagnostics;

namespace FMT.Hash.Tests
{
    [TestClass]
    public class Fnv64Tests
    {
        [TestMethod]
        public void Fnv64KnownList()
        {
            // Arrange
            Dictionary<string, ulong> expectedResults = new Dictionary<string, ulong>()
            {
                { "buttonData.ini", 9263688441353523713 },
            };

            foreach (var kvp in expectedResults)
            {
                string input = kvp.Key;
                ulong expected = kvp.Value;

                var result = Fnv64.FNV64_String8_Lower(input);
                Debug.WriteLine($"{input}:{expected} -> {result} = {expected == result}");
            }

        }

    }
}
