using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    private float _dist = 12.0f;
    private float _height = 4.0f;
    private float _xCameraSpeed = 20.0f;
    private float _yCameraSpeed = 10.0f;
    private float _xCameraAngles = 0.0f;
    private float _yCameraAngles = 0.0f;
    private float _yMinLimit = -20f;
    private float _yMaxLimit = 80f;

    float ClampAngle(float angle, float min, float max)

    {
        if (angle < -360)

            angle += 360;

        if (angle > 360)

            angle -= 360;

        return Mathf.Clamp(angle, min, max);

    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 angles = transform.eulerAngles;
        _xCameraAngles = angles.y;
        _yCameraAngles = angles.x;

    }

    // Update is called once per frame
    void Update()
    {
        _xCameraAngles += Input.GetAxis("Mouse X") * _xCameraSpeed * 0.1f;
        _yCameraAngles -= Input.GetAxis("Mouse Y") * _yCameraSpeed * 0.1f;

        _yCameraAngles = ClampAngle(_yCameraAngles, _yMinLimit, _yMaxLimit);

        Quaternion cameraRotation = Quaternion.Euler(_yCameraAngles, _xCameraAngles, 0);
        Vector3 cameraPosition = cameraRotation * new Vector3(0, _height, -_dist) + target.position;

        transform.rotation = cameraRotation;
        transform.position = cameraPosition;
        
    }
}
