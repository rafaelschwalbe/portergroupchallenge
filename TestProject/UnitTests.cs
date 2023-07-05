using ChallengeLibrary;

namespace TestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void NumberToTextTestMethod()
        {
            string result;

            result = NumberToTextChallenge.NumberToText(0);
            Assert.AreEqual("zero", result);

            result = NumberToTextChallenge.NumberToText(100);
            Assert.AreEqual("cem", result);

            result = NumberToTextChallenge.NumberToText(15);
            Assert.AreEqual("quinze", result);

            result = NumberToTextChallenge.NumberToText(20);
            Assert.AreEqual("vinte", result);

            result = NumberToTextChallenge.NumberToText(35);
            Assert.AreEqual("trinta e cinco", result);

            result = NumberToTextChallenge.NumberToText(123);
            Assert.AreEqual("cento e vinte e três", result);

            result = NumberToTextChallenge.NumberToText(795);
            Assert.AreEqual("setecentos e noventa e cinco", result);
            
            result = NumberToTextChallenge.NumberToText(1000);
            Assert.AreEqual("um mil", result);

            result = NumberToTextChallenge.NumberToText(10000);
            Assert.AreEqual("dez mil", result);

            result = NumberToTextChallenge.NumberToText(10001);
            Assert.AreEqual("dez mil e um", result);

            result = NumberToTextChallenge.NumberToText(11018);
            Assert.AreEqual("onze mil e dezoito", result);

            result = NumberToTextChallenge.NumberToText(11029);
            Assert.AreEqual("onze mil e vinte e nove", result);

            result = NumberToTextChallenge.NumberToText(611329);
            Assert.AreEqual("seiscentos e onze mil e trezentos e vinte e nove", result);
            
            result = NumberToTextChallenge.NumberToText(1611329);
            Assert.AreEqual("um milhão e seiscentos e onze mil e trezentos e vinte e nove", result);
            
            result = NumberToTextChallenge.NumberToText(20611329);
            Assert.AreEqual("vinte milhão e seiscentos e onze mil e trezentos e vinte e nove", result);
            
            result = NumberToTextChallenge.NumberToText(123456789);
            Assert.AreEqual("cento e vinte e três milhão e quatrocentos e cinquenta e seis mil e setecentos e oitenta e nove", result);
            
            result = NumberToTextChallenge.NumberToText(999999999);
            Assert.AreEqual("novecentos e noventa e nove milhão e novecentos e noventa e nove mil e novecentos e noventa e nove", result);

            result = NumberToTextChallenge.NumberToText(1000000000);
            Assert.AreEqual("um bilhão", result);

            //result = NumberToTextChallenge.NumeroPorExtenso(int.MaxValue);//2.147.483.647
            //Assert.AreEqual("dois bilhão e cento e quarenta e sete milhão quatrocentos e oitenta e três mil e seiscentos e quarenta e sete", result);
        }

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