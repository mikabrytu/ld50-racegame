using PathCreation;
using UnityEngine;

namespace Mikabrytu.LD50.Systems
{
    public class MoveSystem
    {
        private Transform transform;
        private PathCreator pathCreator;
        private float pathFollowed;
        private float multiplier;
        private float distanceToPath;
        private bool isTurbo;

        public MoveSystem(Transform transform, PathCreator pathCreator, float distanceToPath)
        {
            this.transform = transform;
            this.pathCreator = pathCreator;
            this.distanceToPath = distanceToPath;

            CalcPath();
        }

        public void Move(float speed)
        {
            if (isTurbo)
            {
                transform.Translate(Vector3.forward * (speed * multiplier) * Time.deltaTime);
                return;
            }

            var point = pathCreator.path.GetPointAtDistance(pathFollowed);
            if (Vector3.Distance(transform.position, point) > distanceToPath)
            {
                MoveToPath(speed, point);
                return;
            }
            
            FollowPath(speed);
        }

        public void ActivateTurbo(float multiplier, bool activate)
        {
            isTurbo = activate;
            this.multiplier = multiplier;
        }

        private void FollowPath(float speed)
        {
            pathFollowed += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(pathFollowed);
            transform.rotation = pathCreator.path.GetRotationAtDistance(pathFollowed);
        }

        private void MoveToPath(float speed, Vector3 target)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void CalcPath()
        {
            pathFollowed = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}