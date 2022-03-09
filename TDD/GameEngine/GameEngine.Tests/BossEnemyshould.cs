using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossEnemyshould
    {
        private readonly ITestOutputHelper _output;

        public BossEnemyshould(ITestOutputHelper output)
        {
            _output = output;

        }

        [Fact]
        [Trait("Category", "Boss")]
        public void HaveCorrectPower()
        {
            _output.WriteLine("Creating Boss Enemy");
            //Asserting Floating Point Values
            BossEnemy sut = new BossEnemy();

            //Set Decimal Places to 3 places
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);

        }







    }
}
