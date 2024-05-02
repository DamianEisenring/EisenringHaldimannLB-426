using CasinoMacher.Games;

namespace Unittests_Casinomacher
{
    [TestClass]
    public class UnitTest1
    {
        //Next three Methods are for slots
        [TestMethod]
        public void Spin_ReturnsNonEmptyResult()
        {
            // Arrange
            var slotMachine = new SlotMachine();

            // Act
            var result = slotMachine.Spin();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void CalculatePayout_NoWin_ReturnsNegativeBet()
        {
            // Arrange
            var slotMachine = new SlotMachine();
            var symbols = new string[] { "1", "2", "3" }; // Annahme: Kein Gewinn
            int bet = 10;

            // Act
            var payout = slotMachine.CalculatePayout(symbols, bet);

            // Assert
            Assert.AreEqual(-bet, payout);
        }

        [TestMethod]
        public void CalculatePayout_MatchingSymbols_ReturnsDoubleBet()
        {
            // Arrange
            var slotMachine = new SlotMachine();
            var symbols = new string[] { "7", "7", "7" }; // Annahme: Drei gleiche Symbole
            int bet = 10;

            // Act
            var payout = slotMachine.CalculatePayout(symbols, bet);

            // Assert
            Assert.AreEqual(bet * 2, payout);
        }





        [TestMethod]
        public void IsEven_EvenNumber_ReturnsTrue()
        {
            // Arrange
            var roulette = new Roulette();
            int number = 2;

            // Act
            bool isEven = roulette.IsEven(number);

            // Assert
            Assert.IsTrue(isEven);
        }

        [TestMethod]
        public void IsEven_OddNumber_ReturnsFalse()
        {
            // Arrange
            var roulette = new Roulette();
            int number = 3;

            // Act
            bool isEven = roulette.IsEven(number);

            // Assert
            Assert.IsFalse(isEven);
        }

        [TestMethod]
        public void GetBet_ValidColor_Red_ReturnsBetAmount()
        {
            // Arrange
            var roulette = new Roulette();
            string answer = "red";
            int expectedBetAmount = 10; // Assuming user inputs 10 as bet amount

            // Act
            int betAmount;
            using (StringReader sr = new StringReader("10"))
            {
                Console.SetIn(sr);
                betAmount = roulette.GetBet(answer);
            }

            // Assert
            Assert.AreEqual(expectedBetAmount, betAmount);
        }

        [TestMethod]
        public void GetBet_ValidNumber_20_ReturnsBetAmount()
        {
            // Arrange
            var roulette = new Roulette();
            string answer = "20";
            int expectedBetAmount = 20; // Assuming user inputs 20 as bet amount

            // Act
            int betAmount;
            using (StringReader sr = new StringReader("20"))
            {
                Console.SetIn(sr);
                betAmount = roulette.GetBet(answer);
            }

            // Assert
            Assert.AreEqual(expectedBetAmount, betAmount);
        }
    }
}