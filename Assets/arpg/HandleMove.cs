using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace arpg
{
    /// <summary>
    /// The movement handler.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class HandleMove : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private bool _isSmoothMoving = false;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            /* Subscribe to input events */
            InputManager.Instance.Subscribe(OnInputEvent);
        }

        private void OnDestroy()
        {
            InputManager.Instance.Unsubscribe(OnInputEvent);
        }

        private void Update()
        {
            /* Handle smooth movement */
            if (_isSmoothMoving)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.value), out var hit, Mathf.Infinity, LayerMask.GetMask(new string[] { "Terrain-Walkable", "Terrain-Obstacle" })))
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Terrain-Obstacle"))
                    {
                        /* Do nothing, we clicked a non-floor */
                        return;
                    }
                
                    /* Handle the pathing */
                    _agent.SetDestination(hit.point);
                }
            }
        }

        /// <summary>
        /// The event used to catch inputs.
        /// </summary>
        /// <param name="ctx"></param>
        private void OnInputEvent(InputAction.CallbackContext ctx)
        {
            switch (ctx.action.name)
            {
                case "MoveCommand":
                    if(ctx.performed) OnMoveCommand();
                    break;
                case "MoveHeld":
                    if (ctx.performed) OnMoveHeldStarted();
                    else if(ctx.canceled) OnMoveHeldEnded();
                    break;
                default:
                    break;
            }
        }

        private void OnMoveHeldStarted()
        {
            Debug.Log("Held!");
            _isSmoothMoving = true;
        }
        
        private void OnMoveHeldEnded()
        {
            Debug.Log("No longer held!");
            if (_isSmoothMoving)
            {
                _agent.SetDestination(transform.position);
            }
            _isSmoothMoving = false;
        }

        /// <summary>
        /// A callback for the movement command being utilized.
        /// </summary>
        private void OnMoveCommand()
        {
            /* Figure out the world collision point */
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.value), out var hit, Mathf.Infinity, LayerMask.GetMask(new string[] { "Terrain-Walkable", "Terrain-Obstacle" })))
            {
                Debug.Log($"Hit at {hit.point} with layer {LayerMask.LayerToName(hit.transform.gameObject.layer)}");
                
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Terrain-Obstacle"))
                {
                    /* Do nothing, we clicked a non-floor */
                    return;
                }
                
                /* Handle the pathing */
                _agent.SetDestination(hit.point);
            }
            
        }
    }

}
