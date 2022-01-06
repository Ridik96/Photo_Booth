using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject rotateTarget;
    private float rotSpeed = 10f;
    private Vector3 prewiosPosition;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            prewiosPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(1))
        {
            Vector3 direction = prewiosPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = target.transform.position;

            transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            transform.Translate(new Vector3(0, 0, -10));

            prewiosPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed;

            rotateTarget.transform.Rotate(Vector3.forward, -rotX);
            rotateTarget.transform.Rotate(Vector3.right, rotY);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cam.fieldOfView--;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cam.fieldOfView++;
        }


    }
}
