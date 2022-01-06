using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotSpeed = 10f;

    public void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed;

       transform.Rotate(Vector3.up, -rotX);
       transform.Rotate(Vector3.forward, rotY);
    }
}
