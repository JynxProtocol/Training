using System;
using Xunit;

namespace GameEngine.Tests
{
    //Asserts Against Objects
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
      
        [Fact]
        
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);

        }

        [Fact(Skip = "Don't need to run this")]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);

        }

        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);

        }


        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            //Assert and get cast result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            //Additional asserts on typed object
            Assert.Equal("Zombie King", boss.Name);


        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            //Assert.IsType<Enemy>(enemy);
            Assert.IsAssignableFrom<Enemy>(enemy);
        }


        //Asserting on Object Instance

        [Fact]
        public void CreateSeperateInstance()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);


        }

        //Asserting on Code that throws Exceptions


        [Fact]
        public void NotAllowNullName()
        {

            EnemyFactory sut = new EnemyFactory();

            //Assert.Throws<ArgumentNullException>( () => sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }


        [Fact]
        public void OnlyAllowKingOrQueenbossEnemies()
        {

            EnemyFactory sut = new EnemyFactory();

            EnemyCreationException ex =
                Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));
            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }





    }
}
