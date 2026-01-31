using NUnit.Framework;

namespace Omotenashi.Tests
{
    public class HealthUnitTests
    {
        Health _testHealth;
        int initialHealth = 10;

        [SetUp]
        public void Setup()
        {
            _testHealth = new Health(initialHealth);
        }

        [TearDown]
        public void TearDown()
        {
            _testHealth = null;
        }
        
        // A Test behaves as an ordinary method
        [Test]
        public void Test01Initialisation()
        {
            Assert.NotNull(_testHealth, "_testHealth is null");
            Assert.AreEqual(_testHealth.CurrentHealth, initialHealth, "_testHealth is not being initialised with the correct initial health values");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(6)]
        [TestCase(-5)]
        [Test]
        public void Test02HealthDecrease(int decreaseHealthAmount)
        { 
            _testHealth.DecreaseHealth(decreaseHealthAmount);

            if (decreaseHealthAmount > 0)
            {
                Assert.AreEqual(_testHealth.CurrentHealth, (initialHealth - decreaseHealthAmount), "Health not decreasing correctly. Is {0} when it should be {1}", _testHealth.CurrentHealth, (initialHealth - decreaseHealthAmount));
            }
            Assert.LessOrEqual(_testHealth.CurrentHealth, initialHealth);
        }

        [TestCase(0, true)]
        [TestCase(3, true)]
        [TestCase(10, false)]
        [TestCase(15, false)]
        public void Test03HealthReachesZero(int decreaseHealthAmount, bool expectedResult)
        {
            _testHealth.DecreaseHealth(decreaseHealthAmount);
            
            Assert.AreEqual(_testHealth.IsHealthAboveZero(), expectedResult, "Health check is incorrect.");
        }
    }
}