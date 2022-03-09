using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;

        //public PlayerCharacterShould()
        //{
        //    _sut = new PlayerCharacter();
        //} 
        //Asserting String Values

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Creating new PlayerCharacter");
            _sut = new PlayerCharacter();

        }

        public void Dispose()
        {
            _output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");    
            //_sut.Dispose();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            //PlayerCharacter sut = new PlayerCharacter(); //Now Declared as a Private Value

            Assert.True(_sut.IsNoob);

        }

        [Fact]
        public void CalculateFullName()
        {

           //PlayerCharacter sut = new PlayerCharacter();

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", _sut.FullName);


        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.StartsWith("Sarah", _sut.FullName);


        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.EndsWith("Smith", _sut.FullName);


        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            _sut.FirstName = "SARAH";
            _sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", _sut.FullName, ignoreCase: true);


        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Contains("ah Sm", _sut.FullName);


        }


        [Fact]
        public void CalculateFullNameWithTitleCase()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);


        }

        [Fact]
        public void StartWithDefaultHealth()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, _sut.Health);


        }


        //Asserting Numeric Values
        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, _sut.Health);


        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            _sut.Sleep(); //Expect increase between 1 to 100 inclusive

            //Assert.True(sut.Health >= 101 && sut.Health <= 200);
            //Assert.InRange<int>(sut.Health, 101, 200);
            Assert.InRange(_sut.Health, 101, 200);

        }

        //Asert Null Values

        [Fact]
        public void NotHaveNickNameByDefault()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(_sut.Nickname);
            //Assert.NotNull(sut.Nickname);

        }

        //Asserting with Collections

        [Fact]
        public void HaveALongbow()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", _sut.Weapons);


        }

        [Fact]
        public void NotHaveAStaffOfWounder()
        {

            //PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff Of Wounder", _sut.Weapons);


        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            //PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }


        [Fact]
        public void HaveAllExpectedWeapons()
        {
            //PlayerCharacter sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }


        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            //PlayerCharacter sut = new PlayerCharacter();


            //Replace the use of a for loop
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));

        }


        //Asserting Events are Rasied


        [Fact]
        public void RasieSleptEvent()
        {
            //PlayerCharacter sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }


        [Fact]
        public void RaisePropertychangeEvent()
        {
            //PlayerCharacter sut = new PlayerCharacter();

            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }


    }
}