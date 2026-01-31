using UnityEngine;


namespace Omotenashi
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _mentalHealth;
        public int MentalHealth { get => _mentalHealth; }
        
        //Components
        private Health _health;

        void Awake()
        {
            _health = new Health(_mentalHealth);
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