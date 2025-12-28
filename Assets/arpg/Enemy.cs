using System;
using UnityEngine;
using UnityEngine.AI;

namespace arpg
{
    /// <summary>
    /// An enemy controller.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        /// <summary>
        /// The agent for navigation.
        /// </summary>
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            /* Get a reference to the player */
            var player = GameObject.FindGameObjectWithTag("Player");
            
            /* Move towards them */
            _agent.SetDestination(player.transform.position);
        }
    }
}