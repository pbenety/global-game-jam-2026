using System;
using UnityEngine;

namespace Omotenashi
{
    public class Health
    {
        private int _currentHealth;
        private int _maxHealth;
        public int CurrentHealth {  get { return _currentHealth; } set { _currentHealth = value; } }
        
        public Health(int initialHealth)
        {
            _currentHealth = initialHealth;
            _maxHealth = initialHealth;
        }

        public void IncreaseHealth(int amount)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            UIPrototype.UIEvents.MentalHealthChanged?.Invoke(_currentHealth);
        }

        public void DecreaseHealth(int decreaseAmount)
        {
            _currentHealth -= decreaseAmount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            UIPrototype.UIEvents.MentalHealthChanged?.Invoke(_currentHealth);
        }

        public bool IsHealthAboveZero()
        {
            return _currentHealth > 0;
        }

        public void HealthReset()
        {
            _currentHealth = _maxHealth;
        }
    }
}