using ChallengeLibrary;

namespace TestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SumChallengeTestMethod()
        {
            var inArray = new List<int>();
            while (inArray.Count < 1000000)
                inArray.Add(1);

            var sumResponse = SumChallenge.SumIntArray(inArray.ToArray());
            Assert.AreEqual(1000000, sumResponse);

            inArray.Clear();
            while (inArray.Count < 1000000)
                inArray.Add(2);

            sumResponse = SumChallenge.SumIntArray(inArray.ToArray());
            Assert.AreEqual(2000000, sumResponse);

            inArray.Clear();
            Random random = new Random();
            while (inArray.Count < 1000000)
                inArray.Add(random.Next(1, 5));

            sumResponse = SumChallenge.SumIntArray(inArray.ToArray());
            Assert.IsTrue(sumResponse >= 1000000 && sumResponse <= 5000000);

            //array de entrada com mais q 1000000 itens
            try
            {
                inArray.Clear();
                while (inArray.Count < 1000001)
                    inArray.Add(1);
                sumResponse = SumChallenge.SumIntArray(inArray.ToArray());
                Assert.Fail("Deveria lançar uma ArgumentException");
            }
            catch (ArgumentException ex) { }
            catch (Exception ex) { Assert.Fail($"Deveria lançar uma ArgumentException. Foi lançada a exceção: {ex.Message}"); }

            //soma maior q long.MaxValue
            try
            {
                inArray.Clear();
                while (inArray.Count < 1000000)
                    inArray.Add(int.MaxValue);
                sumResponse = SumChallenge.SumIntArray(inArray.ToArray());
                Assert.Fail("Deveria lançar uma OverflowException");
            }
            catch (OverflowException ex) { }
            catch (Exception ex) { Assert.Fail($"Deveria lançar uma ArgumentException. Foi lançada a exceção: {ex.Message}"); }
        }
    }
}