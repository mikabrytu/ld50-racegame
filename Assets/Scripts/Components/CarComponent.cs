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
        [SerializeField] private float turboMultiplier;

        private MoveSystem moveSystem;

        private void Start()
        {
            moveSystem = new MoveSystem(transform, pathCreator);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                moveSystem.ActivateTurbo(turboMultiplier, true);
            
            if (Input.GetKeyUp(KeyCode.Space))
                moveSystem.ActivateTurbo(turboMultiplier, false);
            
            moveSystem.Move(speed);
        }
    }
}
