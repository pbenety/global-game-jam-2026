using NUnit.Framework;

namespace Omotenashi.Tests
{
    public class EmotionUnitTests
    {
        private Emotion _testEmotion;

        [SetUp]
        public void Setup()
        {
            _testEmotion = new Emotion();
        }

        [TearDown]
        public void TearDown()
        {
            _testEmotion = null;
        }


        [Test]
        public void Test01EmotionDefaultInitialisation()
        {
            Assert.IsNotNull(_testEmotion, "_testEmotion is null");
            Assert.AreEqual(_testEmotion.GetEmotion, Emotions.Neutral, "Initial emotion is incorrect. Is {0} when it should be {1}.", _testEmotion.GetEmotion, Emotions.Neutral);
        }

        [TestCase(Emotions.Angry)]
        [TestCase(Emotions.Happy)]
        [TestCase(Emotions.Sad)]
        [Test]
        public void Test02CustomEmotionInitialisation(Emotions initialEmotion)
        {
            _testEmotion = new Emotion(initialEmotion);
            
            Assert.IsNotNull(_testEmotion, "_testEmotion is null");
            Assert.AreEqual(_testEmotion.GetEmotion, initialEmotion, "Initial emotion is incorrect. Is {0} when it should be {1}.", _testEmotion.GetEmotion, initialEmotion);
        }

        [Test]
        public void Test03TestEmotionDelegates()
        {
            bool checkOnMotionSelected = false;
            
            Emotion.OnEmotionSelected += delegate { checkOnMotionSelected = true; };
            _testEmotion.EmotionSelected();
            
            Assert.IsTrue(checkOnMotionSelected, "Delegate not triggering");
        }
    }
}