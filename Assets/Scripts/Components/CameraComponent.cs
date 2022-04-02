using UnityEngine;

namespace Mikabrytu.LD50.Components
{
    public class CameraComponent: MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        private void LateUpdate()
        {
            var position = target.position + offset;
            position.y = transform.position.y + offset.y;
            
            transform.position = position;
            transform.LookAt(target);
        }
    }
}