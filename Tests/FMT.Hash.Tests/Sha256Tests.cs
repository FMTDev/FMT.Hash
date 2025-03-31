namespace FMT.Hash.Tests
{
    [TestClass]
    public sealed class Sha256Tests
    {

        /// <summary>
        /// Test the Sha256 produces the same result as the true result found via SDK generation
        /// TODO: It currently doesn't. :)
        /// </summary>
        [TestMethod]

        public void Test_SHA256Hash32_Lowercase_RT()
        {
            var attempt1 = Sha256.SHA256Hash32_Lowercase_RT("AttribSchema_gp_kickshot_shooting");
            var attempt2 = Sha256.SHA256Hash32_Lowercase_RT("AttribSchema_gp_kickshot_shooting", "1029");

            Assert.AreEqual(1303288196u, attempt1);

        }
    }
}
