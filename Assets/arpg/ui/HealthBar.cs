using System;
using UnityEngine;
using UnityEngine.UI;

namespace arpg.ui
{
    /// <summary>
    /// A health bar floating above an entity.
    /// </summary>
    public class HealthBar : MonoBehaviour
    {
        /// <summary>
        /// The sprite representing health.
        /// </summary>
        public Image FillSprite;

        private bool _lateStart = true;
        
        private void Start()
        {
            /* Set the callback from a health object in the hierarchy */
            var health = transform.GetComponentInParent<Health>();
            health.OnHealthChange += OnUpdate;

            OnUpdate(health.CurrentHealth, health.MaxHealth, 0);
        }

        /// <summary>
        /// The callback used to update the health bar.
        /// </summary>
        /// <param name="curr"></param>
        /// <param name="total"></param>
        /// <param name="delta"></param>
        private void OnUpdate(float curr, float total, float delta)
        {
            FillSprite.fillAmount = curr / total;
        }
    }
}