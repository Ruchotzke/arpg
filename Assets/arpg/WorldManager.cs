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
        public static WorldManager instance;
        
        private NavMeshSurface _surface;

        private void Awake()
        {
            /* Singleton */
            if (instance != null) Destroy(gameObject);
            instance = this;
            
            /* Build the surface */
            _surface = GetComponent<NavMeshSurface>();
            _surface.BuildNavMesh();
        }
    }
}