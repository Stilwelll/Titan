using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterCamera : MonoBehaviour
{
    public float cameraSpeed = 3.0f;
    public float scrollWheel;
    public float scrollSpeed = 100.0f;

    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("CameraFocalPoint");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraMovement();
        GetScroll();
    }

    void CameraMovement()
    {
        // basic WASD camera Movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime, Space.World);
        }

    }

    void GetScroll()
    {
        // Allows the player to zoom in and out. Very basic
        scrollWheel = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        transform.Translate(Vector3.forward * scrollWheel * Time.deltaTime);
    }

    void RotateAroundPoint()
    {
        // allows the camera to rotate around a singular point on the ground
        // transform.RotateAround(focalPoint, new Vector3(0, 1, 0), 10 * Time.deltaTime);

    }


}
