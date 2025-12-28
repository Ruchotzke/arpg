using System;
using UnityEngine;

namespace arpg.ui
{
    /// <summary>
    /// A component used to constantly align this object's rotation with the camera.
    /// </summary>
    public class Billboard : MonoBehaviour
    {
        private Camera _camera;
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            transform.rotation = _camera.transform.rotation;
        }
    }
}