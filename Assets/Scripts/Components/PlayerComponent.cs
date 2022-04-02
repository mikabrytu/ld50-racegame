using UnityEngine;

namespace Mikabrytu.LD50.Components
{
    public class PlayerComponent : CarComponent
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                moveSystem.ActivateTurbo(turboMultiplier, true);
            
            if (Input.GetKeyUp(KeyCode.Space))
                moveSystem.ActivateTurbo(turboMultiplier, false);
            
            base.Update();
        }
    }
}
