using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGCamera
{
    public class TopDownCamera : MonoBehaviour
    {
        public Transform Target;
        [SerializeField]
        private float Height = 4f;
        [SerializeField]
        private float Distance = 10f;
        [SerializeField]
        private float Angle = 30f;
        [SerializeField]
        private float SmoothSpeed = 0.5f;

        private Vector3 refVelocity;
        // Start is called before the first frame update
        void Start()
        {
            HandleCamera();
        }

        // Update is called once per frame
        void Update()
        {
            HandleCamera();
        }

        protected virtual void HandleCamera()
        {
            if (!Target)
            {
                return;
            }

            //Build world possition Vector
            Vector3 worldPosition = (Vector3.forward * -Distance) + Vector3.up * Height;
            Debug.DrawLine(Target.position, worldPosition, Color.red);

            //Build our Rotation Vector
            Vector3 rotatedVector = Quaternion.AngleAxis(Angle, Vector3.up) * worldPosition;
            Debug.DrawLine(Target.position, rotatedVector, Color.green);

            //Move our position
            Vector3 flatTargetPosition = Target.position;
            //flatTargetPosition.y = 0f;
            Vector3 finalPosition = flatTargetPosition + rotatedVector;
            Debug.DrawLine(Target.position, finalPosition, Color.blue);

            transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, SmoothSpeed);
            transform.LookAt(flatTargetPosition);
        }
    }
}

