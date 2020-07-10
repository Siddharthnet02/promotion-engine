
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PromotionEngine.TestCase
{
    [TestClass]
    public class PromoEngineTest
    {
        [TestMethod]
        [DataRow("ABC",100)]
        public void PrintInvoice_Should_Return_100(string input, string output)
        {
            Program program = new Program();
            decimal result = program.PrintInvoice(input);
            Assert.Equals(result, output);
        }

        [TestMethod]
        [DataRow("AAAAABBBBBC", 370)]
        public void PrintInvoice_Should_Return_370(string input, string output)
        {
            Program program = new Program();
            decimal result = program.PrintInvoice(input);
            Assert.Equals(result, output);
        }
        [TestMethod]
        [DataRow("AAABBBBBCD", 280)]
        public void PrintInvoice_Should_Return_280(string input, string output)
        {
            Program program = new Program();
            decimal result = program.PrintInvoice(input);
            Assert.Equals(result, output);
        }
    }
}
