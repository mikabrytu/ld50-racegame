using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Mikabrytu.LD50.Components
{
    public class CameraComponent: MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float zPlaneOffset = -10;

        private void Update()
        {
            var position = target.position;
            position.y = transform.position.y;
            position.z += zPlaneOffset;
            transform.position = position;
        }
    }
}