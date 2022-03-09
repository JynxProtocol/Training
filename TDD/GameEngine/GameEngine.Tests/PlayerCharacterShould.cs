using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        //Asserting String Values

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);

        }

        [Fact]
        public void CalculateFullName()
        {

            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", sut.FullName);


        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {

            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.StartsWith("Sarah", sut.FullName);


        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {

            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.EndsWith("Smith", sut.FullName);


        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {

            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "SARAH";
            sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", sut.FullName, ignoreCase: true);


        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {

            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Contains("ah Sm", sut.FullName);


        }


        [Fact]
        public void CalculateFullNameWithTitleCase()
        {

            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);


        }

        [Fact]
        public void StartWithDefaultHealth()
        {

            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);


        }


        //Asserting Numeric Values
        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {

            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);


        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {

            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep(); //Expect increase between 1 to 100 inclusive

            //Assert.True(sut.Health >= 101 && sut.Health <= 200);
            //Assert.InRange<int>(sut.Health, 101, 200);
            Assert.InRange(sut.Health, 101, 200);

        }

        //Asert Null Values

        [Fact]
        public void NotHaveNickNameByDefault()
        {

            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
            //Assert.NotNull(sut.Nickname);

        }

        //Asserting with Collections

        [Fact]
        public void HaveALongbow()
        {

            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);


        }

        [Fact]
        public void NotHaveAStaffOfWounder()
        {

            PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff Of Wounder", sut.Weapons);


        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }


        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }


        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();


            //Replace the use of a for loop
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));

        }


        //Asserting Events are Rasied


        [Fact]
        public void RasieSleptEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }


        [Fact]
        public void RaisePropertychangeEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }


    }
}