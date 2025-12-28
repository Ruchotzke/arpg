using System;
using Unity.AI.Navigation;
using UnityEngine;

namespace arpg
{
    /// <summary>
    /// The manager used for interaction with the world.
    /// </summary>
    [RequireComponent(typeof(NavMeshSurface))]
    public class WorldManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton reference.
        /// </summary>
        public static WorldManager Instance;
        
        private NavMeshSurface _surface;

        private void Awake()
        {
            /* Singleton */
            if (Instance != null) Destroy(gameObject);
            Instance = this;
            
            /* Build the surface */
            _surface = GetComponent<NavMeshSurface>();
            _surface.BuildNavMesh();
        }
    }
}