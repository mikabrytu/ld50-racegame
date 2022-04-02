using PathCreation;
using UnityEngine;

namespace Mikabrytu.LD50.Systems
{
    public class MoveSystem
    {
        private Transform transform;
        private PathCreator pathCreator;
        private float pathFollowed;

        public MoveSystem(Transform transform, PathCreator pathCreator)
        {
            this.transform = transform;
            this.pathCreator = pathCreator;

            pathFollowed = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        public void Move(float speed)
        {
            pathFollowed += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(pathFollowed);
            transform.rotation = pathCreator.path.GetRotationAtDistance(pathFollowed);
        }
    }
}