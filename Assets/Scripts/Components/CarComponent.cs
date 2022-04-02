using Mikabrytu.LD50.Systems;
using PathCreation;
using UnityEngine;

namespace Mikabrytu.LD50.Components
{
    public class CarComponent : MonoBehaviour
    {
        [SerializeField] public float turboMultiplier;
        
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private float speed;
        [SerializeField] private float distanceToPath;

        protected MoveSystem moveSystem;

        private void Awake()
        {
            moveSystem = new MoveSystem(transform, pathCreator, distanceToPath);
        }

        public void Update()
        {
            moveSystem.Move(speed);
        }
    }
}
