using PathCreation;
using UnityEngine;

namespace Mikabrytu.LD50.Components
{
    public class CarComponent : MonoBehaviour
    {
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private float speed;

        private float pathFollowed;

        private void Update()
        {
            pathFollowed += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(pathFollowed);
            transform.rotation = pathCreator.path.GetRotationAtDistance(pathFollowed);
        }
    }
}
