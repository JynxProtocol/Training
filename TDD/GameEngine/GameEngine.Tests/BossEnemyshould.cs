using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyshould
    {
        [Fact]
        public void HaveCorrectPower()
        {
            //Asserting Floating Point Values
            BossEnemy sut = new BossEnemy();

            //Set Decimal Places to 3 places
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);

        }







    }
}
