using System.Collections.Generic;
using System.Diagnostics;

namespace FMT.Hash.Tests
{
    [TestClass]
    public class Sha256Tests
    {
        [TestMethod]
        public void Sha256KnownListOfAttribSchemaTypes()
        {
            // Arrange
            Dictionary<string, uint> expectedResults = new Dictionary<string, uint>()
            {
                { "AttribSchema_gp_kickshot_shooting", 1303288196 },
                { "AttribSchema_gp_actor_action", 1344965732 },
                { "AttribSchema_gp_actor_movement", 4238001312 },
                { "AttribSchema_gp_actor_facialanim", 2082094922 }
            };

            foreach (var kvp in expectedResults)
            {
                string input = kvp.Key;
                uint expected = kvp.Value;

                var result = (uint)Sha256.SHA256Hash32_Lowercase(input, "1028");
                Debug.WriteLine($"{input}:{expected} -> {result} = {expected == result}");
            }

        }

        [TestMethod]
        public void Sha256KnownListOfAttribSchemaProps()
        {
            // Arrange
            Dictionary<string, uint> expectedResults = new Dictionary<string, uint>()
            {
                { "SHOT_ErrorScalarVsAimInsidePostSmallGoal", 2841633721 },
            };

            foreach (var kvp in expectedResults)
            {
                string input = kvp.Key;
                uint expected = kvp.Value;

                var result = (uint)Sha256.SHA256Hash32_Lowercase(input, "1028");
                Debug.WriteLine($"{input}:{expected} -> {result} = {expected == result}");
            }

        }


    }
}
