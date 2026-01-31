using UnityEngine;


namespace Omotenashi
{
    public class Player : MonoBehaviour
    {
        private int _mentalHealth;

        public int MentalHealth
        {
            get => _mentalHealth;
        }

        private PlayerStates _currentState;

        public PlayerStates CurrentState
        {
            get { return _currentState; }
        }



    }


    public enum PlayerStates
    {
        Neutral,
        Happy,
        Sad,
        Angry
    }
}