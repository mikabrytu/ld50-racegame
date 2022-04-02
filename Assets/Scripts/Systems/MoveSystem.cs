using PathCreation;
using UnityEngine;

namespace Mikabrytu.LD50.Systems
{
    public class MoveSystem
    {
        private float pathFollowed;
        private float multiplier;
        private bool isTurbo;
        private bool canMove;
        
        private readonly Transform transform;
        private readonly PathCreator pathCreator;
        private readonly float distanceToPath;

        public MoveSystem(Transform transform, PathCreator pathCreator, float distanceToPath)
        {
            this.transform = transform;
            this.pathCreator = pathCreator;
            this.distanceToPath = distanceToPath;
            
            StartMovement();
            CalcPath();
        }

        public void Move(float speed)
        {
            if (!canMove) return;

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

            if (activate == false) CalcPath();
        }

        public void StartMovement() => canMove = true;
        
        public void StopMovement() => canMove = false;

        public bool IsTurbo() => isTurbo;

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