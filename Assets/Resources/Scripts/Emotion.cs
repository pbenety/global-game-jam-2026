using System;

namespace Omotenashi
{
    public class Emotion
    {
        private Emotions _emotion;
        public Emotions GetEmotion { get { return _emotion; } }
        
        //Delegate
        public static event Action<Emotions> OnEmotionSelected;

        public Emotion()
        {
            _emotion = Emotions.Neutral;
            SetupDelegates();
        }

        public Emotion(Emotions initEmotion)
        {
            _emotion = initEmotion;
            SetupDelegates();
        }

        private static void SetupDelegates()
        {
            if (OnEmotionSelected == null) OnEmotionSelected = delegate { };
        }

        public void EmotionSelected()
        {
            OnEmotionSelected?.Invoke(_emotion);
        }
    }
}