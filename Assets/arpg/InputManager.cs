using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace arpg
{
    /// <summary>
    /// The input manager used to distribute input items.
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        /// <summary>
        /// The singleton instance of this manager.
        /// </summary>
        public static InputManager Instance;
        
        private PlayerInput _playerInput;
        
        private void Awake()
        {
            /* Singleton */
            if (Instance != null) Destroy(gameObject);
            Instance = this;
            
            /* Grab input */
            _playerInput = GetComponent<PlayerInput>();
        }

        /// <summary>
        /// Subscribe to input events managed by this instance.
        /// </summary>
        /// <param name="callback"></param>
        public void Subscribe(Action<InputAction.CallbackContext> callback)
        {
            //TODO: In the future, it may be better to only have InputManager receive CallbackContext, and delegate out different events (others only sub to what they want)
            _playerInput.onActionTriggered += callback;
        }

        /// <summary>
        /// Unsubscribe to input events managed by this instance.
        /// </summary>
        /// <param name="callback"></param>
        public void Unsubscribe(Action<InputAction.CallbackContext> callback)
        {
            _playerInput.onActionTriggered -= callback;
        }
    }
}