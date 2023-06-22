using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraTransform;
    public float sensitivity;

    // Update is called once per frame
    void Update()
    {
        // Get mouse movement
        float y = -Input.GetAxisRaw("Mouse Y") * sensitivity;
        float x = Input.GetAxisRaw("Mouse X") * sensitivity;
        Vector3 rotation = new(y, x, 0);

        // Up/Down Camera control
        cameraTransform.eulerAngles += new Vector3(rotation.x, 0, 0);

        // Left/Right Camera control
        transform.Rotate(new Vector3(0, rotation.y, 0));

        // Undo the Z axis rotation
        //float z = transform.eulerAngles.z;
        //transform.Rotate(0, 0, -z);
    }
}
