using System;
using TMPro;
using UnityEngine;

namespace Mikabrytu.LD50.View
{
    public class FuelView : MonoBehaviour
    {
        private TextMeshProUGUI fuelDisplay;

        private void Start()
        {
            fuelDisplay = GetComponent<TextMeshProUGUI>();
        }

        public void DisplayFuel(string value)
        {
            fuelDisplay.text = $"Fuel: {value}";
        }
    }
}