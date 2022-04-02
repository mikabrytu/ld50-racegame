using Mikabrytu.LD50.Events;
using UnityEngine;

using Mikabrytu.LD50.Managers;

namespace Mikabrytu.LD50.Components
{
    public class FuelComponent : MonoBehaviour
    {
        [SerializeField] private string fuelable;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals(fuelable))
            {
                EventManager.Raise(new OnPickFuelEvent());
                Destroy(gameObject);
            }
        }
    }
}