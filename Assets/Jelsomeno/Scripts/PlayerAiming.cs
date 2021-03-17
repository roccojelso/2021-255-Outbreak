using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Jelsomeno
{
    public class PlayerAiming : MonoBehaviour
    {

        private Camera cam;

        public Transform debugObject;


        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            AimAtMouse();

        }

        private void AimAtMouse()
        {
            // make a ray and a plane 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, transform.position);

            // does the ray hit the plane?
            if (plane.Raycast(ray, out float dis))
            {

                // find where the ray hit the plane
                Vector3 hitPos = ray.GetPoint(dis);

                debugObject.position = hitPos;

                Vector3 vectorToHitPos = hitPos - transform.position;

                float angle = Mathf.Atan2(vectorToHitPos.x, vectorToHitPos.z);

                angle /= Mathf.PI; // converts from radians to half circles 
                angle *= 180; // converts to half circles to degrees

                transform.eulerAngles = new Vector3(0, angle, 0);

            }
        }
    }
}
