using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    private float dist = 12.0f;
    private float height = 4.0f;
    private float xCameraSpeed = 20.0f;
    private float yCameraSpeed = 10.0f;
    private float xCameraAngles = 0.0f;
    private float yCameraAngles = 0.0f;
    private float yMinLimit = -20f;
    private float yMaxLimit = 80f;

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
        xCameraAngles = angles.y;
        yCameraAngles = angles.x;

    }
    void CameraRotate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        xCameraAngles += Input.GetAxis("Mouse X") * xCameraSpeed * 0.1f;
        yCameraAngles -= Input.GetAxis("Mouse Y") * yCameraSpeed * 0.1f;

        yCameraAngles = ClampAngle(yCameraAngles, yMinLimit, yMaxLimit);

        Quaternion cameraRotation = Quaternion.Euler(yCameraAngles, xCameraAngles, 0);
        Vector3 cameraPosition = cameraRotation * new Vector3(0, height, -dist) + target.position;

        transform.rotation = cameraRotation;
        transform.position = cameraPosition;
        
    }
    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Character").GetComponent<FSMPlayer>().skillTable.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            CameraRotate();
            Debug.Log("변환");
        }

    }
}
