using UnityEngine;
using System;

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
        
        //Delegate
        public static event Action OnGameOver;

        void Awake()
        {
            if (OnGameOver == null)
            {
                OnGameOver = delegate { };
            }
            
            _health = new Health(_mentalHealth);
        }


        void Start()
        {
            Emotion.OnEmotionSelected += MaskUsed;
            Customer.OnGoodReaction += GoodReactionEffects;
            Customer.OnBadReaction += BadReactionEffects;
            Customer.OnNeutral += NeutralReactionEffects;
            UIPrototype.UIEvents.MoneyChanged?.Invoke(_money);
        }

        void OnDestroy()
        {
            Emotion.OnEmotionSelected -= MaskUsed;
            Customer.OnGoodReaction -= GoodReactionEffects;
            Customer.OnBadReaction -= BadReactionEffects;
            Customer.OnNeutral -= NeutralReactionEffects;
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
            UIPrototype.UIEvents.MoneyChanged?.Invoke(_money);
        }

        private void BadReactionEffects()
        {
            _health.DecreaseHealth(1);
        }

        private void NeutralReactionEffects()
        {
            _money += 60;
            
        }

        public void CheckHealth()
        {
            if (!_health.IsHealthAboveZero())
            {
                OnGameOver?.Invoke();
            }
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