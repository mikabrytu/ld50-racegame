using System;
using Mikabrytu.LD50.Systems;
using PathCreation;
using UnityEngine;

namespace Mikabrytu.LD50.Components
{
    public class CarComponent : MonoBehaviour
    {
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private float speed;

        private MoveSystem moveSystem;

        private void Start()
        {
            moveSystem = new MoveSystem(transform, pathCreator);
        }

        private void Update()
        {
            moveSystem.Move(speed);
        }
    }
}
