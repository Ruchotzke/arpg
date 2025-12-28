using System;
using UnityEngine;

namespace arpg
{
    /// <summary>
    /// A component representing the health of something.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// A callback event for when health drops to or below zero.
        /// </summary>
        public event Action OnDeath;

        /// <summary>
        /// An action called when the health of a gameobject is changed.
        /// First arg is current health, second is max, third is delta.
        /// </summary>
        public event Action<float, float, float> OnHealthChange;

        /// <summary>
        /// The max health.
        /// </summary>
        public float MaxHealth
        {
            get => _maxHealth;
            set
            {
                if (_maxHealth == value) return;
                _maxHealth = value;
                OnHealthChange?.Invoke(_currHealth, _maxHealth, 0);
                if(_maxHealth <= 0) OnDeath?.Invoke();
            }
        }

        [SerializeField]
        private float _maxHealth;

        /// <summary>
        /// The current health value.
        /// </summary>
        public float CurrentHealth
        {
            get => _currHealth;
            set
            {
                var delta = value - _currHealth;
                if (delta != 0)
                {
                    _currHealth = value;
                    OnHealthChange?.Invoke(_currHealth, _maxHealth, delta);
                    if(_currHealth <= 0) OnDeath?.Invoke();
                }
            }
        }

        [SerializeField]
        private float _currHealth;


    }
}