using UnityEngine;


namespace Omotenashi
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _mentalHealth;
        public int MentalHealth { get => _mentalHealth; }

        [SerializeField] private int _money;
        public int Money { get => _money; }
        
        //Components
        private Health _health;

        void Awake()
        {
            _health = new Health(_mentalHealth);
        }


        void Start()
        {
            Emotion.OnEmotionSelected += MaskUsed;
        }

        void OnDestroy()
        {
            Emotion.OnEmotionSelected -= MaskUsed;
        }

        private void MaskUsed(Emotions emotion)
        {
            if (emotion != Emotions.Neutral)
            {
                _health.DecreaseHealth(1);
            }
        }

        private void GoodReactionEffects()
        {
            _health.IncreaseHealth(2);
            _money += 120;
        }

        private void BadReactionEffects()
        {
            _health.DecreaseHealth(1);
        }

        private void NeutralReactionEffects()
        {
            _money += 60;
        }

        private void ResetPlayer()
        {
            _health.HealthReset();
            _money = 0;
        }
    }


    public enum Emotions
    {
        Neutral,
        Happy,
        Sad,
        Angry
    }
}