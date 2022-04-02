using UnityEngine;

using Mikabrytu.LD50.Managers;
using Mikabrytu.LD50.Events;

namespace Mikabrytu.LD50.Components
{
    public class PlayerComponent : CarComponent
    {
        [Header("Fuel Settings")] 
        [SerializeField] private float maxFuel;
        [SerializeField] private float normalDecay;
        [SerializeField] private float turboDecay;
        [SerializeField] private float recharge;

        private float currentFuel;
        private bool isMoving;

        #region Unity Messages

        public void Start()
        {
            currentFuel = maxFuel;
            isMoving = true;
            
            EventManager.AddListener<OnPickFuelEvent>(OnPickFuel);
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

        #endregion

        #region Implementation

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

        #endregion

        #region Listeners

        private void OnPickFuel(OnPickFuelEvent e)
        {
            currentFuel += recharge;
        }

        #endregion

        #region Public API

        public float GetFuel() => currentFuel;

        #endregion
    }
}
