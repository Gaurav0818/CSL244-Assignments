using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraYRotation : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;

    public float minVertical = -45.0f;
    public float maxVertical = 45.0f;
    public float sensHorizontal = 1f;
    public float sensVertical = 0.5f;
    
    
    public float rotationX = 0;
    
    
    private void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X")*sensHorizontal,0);
        }
        else if(axes == RotationAxis.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
            rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
            
 

    }
    
}
