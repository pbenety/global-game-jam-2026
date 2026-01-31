using System;
using UnityEngine;

namespace Omotenashi
{
    public class Health
    {
        private int _currentHealth;
        public int CurrentHealth {  get { return _currentHealth; } set { _currentHealth = value; } }
        
        public Health(int initialHealth)
        {
            _currentHealth = initialHealth;
        }

        public void DecreaseHealth(int decreaseAmount)
        {
            _currentHealth -= Mathf.Clamp(decreaseAmount, 0, _currentHealth);
        }

        public bool IsHealthAboveZero()
        {
            return _currentHealth > 0;
        }
    }
}