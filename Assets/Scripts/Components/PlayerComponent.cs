using UnityEngine;

namespace Mikabrytu.LD50.Components
{
    public class PlayerComponent : CarComponent
    {
        [Header("Fuel Settings")] 
        [SerializeField] private float maxFuel;
        [SerializeField] private float normalDecay;
        [SerializeField] private float turboDecay;

        private float currentFuel;
        private bool isMoving;

        public void Start()
        {
            currentFuel = maxFuel;
            isMoving = true;
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                moveSystem.ActivateTurbo(turboMultiplier, true);
            
            if (Input.GetKeyUp(KeyCode.Space))
                moveSystem.ActivateTurbo(turboMultiplier, false);
            
            base.Update();
            SpentFuel(moveSystem.IsTurbo());
        }

        public float GetFuel() => currentFuel;

        private void SpentFuel(bool isTurbo)
        {
            if (!isMoving) return;
            
            currentFuel -= isTurbo ? turboDecay * Time.deltaTime : normalDecay * Time.deltaTime;
            
            if (currentFuel <= 0)
            {
                isMoving = false;
                moveSystem.StopMovement();
            }
        }
    }
}
