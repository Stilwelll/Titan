using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterCamera : MonoBehaviour
{
    public float cameraSpeed = 3.0f;
    public float scrollSpeed = 200.0f;
    public float rotateSpeed = 200.0f;

    private float scrollWheel;
    private float verticalMovement;

    private GameObject focalPoint;
    private GameObject cameraOriginpoint;

    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("CameraFocalPoint");
        cameraOriginpoint = GameObject.Find("Origin Camera");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        WASDCameraMovement();
        GetScrollWheel();
        RotateAroundPoint();
    }

    void WASDCameraMovement()
    {
        // basic WASD camera Movement
        if (Input.GetKey(KeyCode.A))
        {
            cameraOriginpoint.transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            cameraOriginpoint.transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            cameraOriginpoint.transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            cameraOriginpoint.transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);
        }

    }

    void GetScrollWheel()
    {
        // Allows the player to zoom in and out. Very basic
        scrollWheel = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        // hardcoding the maximum and minimum zooming distance (height limit)
        if (transform.position.y > 2.5 && transform.position.y < 9)
        {
            transform.Translate(Vector3.forward * scrollWheel * Time.deltaTime);
        }

        // if maximum zooming distance is reached, then zoom out automatically
        if (transform.position.y < 2.5)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }

        // if maximum zooming distance is reached, then zoom in automatically
        if (transform.position.y > 9)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }

    void RotateAroundPoint()
    {
        // allows the camera to rotate around a singular point on the ground
        float horizontalMovement = Input.GetAxis("Mouse X");
        
        // if the scroll wheel button is held down, then you can move your mouse horizontal to rotate the camera around a point
        if (Input.GetMouseButton(2))
        {
            cameraOriginpoint.transform.RotateAround(focalPoint.transform.position, new Vector3(0, 1, 0), horizontalMovement * rotateSpeed * Time.deltaTime);
        }
    }


}