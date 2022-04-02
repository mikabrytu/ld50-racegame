using UnityEngine;

using Mikabrytu.LD50.Components;
using Mikabrytu.LD50.View;

namespace Mikabrytu.LD50.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("View")]
        [SerializeField] private FuelView fuelView;

        [Space, Header("Components")] 
        [SerializeField] private PlayerComponent player;

        private void Update()
        {
            fuelView.DisplayFuel(player.GetFuel().ToString("00.0"));
        }
    }
}