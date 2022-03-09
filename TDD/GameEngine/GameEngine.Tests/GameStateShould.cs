using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;


        public GameStateShould(GameStateFixture gameStateFixture,
                               ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;

            _output = output;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            //var sut = new GameState();

            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            //sut.Players.Add(player1);
            //sut.Players.Add(player2);
            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            var expectedHealthAfterEearthquake = player1.Health - GameState.EarthquakeDamage;

            //sut.Earthquake();
            _gameStateFixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEearthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEearthquake, player2.Health);
    
        }

        [Fact]
        public void Reset()
        {
            //var sut = new GameState();
            
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            //sut.Players.Add(player1);
            //sut.Players.Add(player2);
            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            //sut.Reset();
            _gameStateFixture.State.Reset();

            //Assert.Empty(sut.Players);
            Assert.Empty(_gameStateFixture.State.Players);
        }
    }
}
