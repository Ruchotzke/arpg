using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

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

        private Health _health;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _health = GetComponent<Health>();
            
            _health.OnDeath += OnDeath;
        }

        private void Update()
        {
            /* Get a reference to the player */
            var player = GameObject.FindGameObjectWithTag("Player");
            
            /* Move towards them */
            _agent.SetDestination(player.transform.position);
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}