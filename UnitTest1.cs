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
    }
}