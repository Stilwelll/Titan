using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterCamera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public float scrollSpeed = 200.0f;
    public float rotateSpeed = 200.0f;
    public float increasedSpeedHeight = 6.0f;

    [SerializeReference] private float minHeight = 2.5f;
    [SerializeReference] private float maxHeight = 9;

    private GameObject focalPoint;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // define the variables with the various game objects in the scene
        focalPoint = GameObject.Find("CameraFocalPoint");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        WASDCameraMovement();
        GetScrollWheel();
        RotateAroundPoint();
        AltCameraMovement();
    }

    void WASDCameraMovement()
    {
        // basic WASD camera Movement
        // if the player is above a certain height on the y-axis, then they can travel 100% faster
        if (Input.GetKey(KeyCode.A) & transform.position.y > increasedSpeedHeight)
        {
            player.transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime * 2f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) & transform.position.y > increasedSpeedHeight)
        {
            player.transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime * 2f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) & transform.position.y > increasedSpeedHeight)
        {
            player.transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime * 2f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) & transform.position.y > increasedSpeedHeight)
        {
            player.transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime * 2f);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);
        }

    }

    void GetScrollWheel()
    {
        // Allows the player to zoom in and out. Very basic
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        // hardcoding the maximum and minimum zooming distance (height limit)
        if (transform.position.y > minHeight & transform.position.y < maxHeight)
        {
            transform.Translate(Vector3.forward * scrollWheel * Time.deltaTime);
        }

        // if maximum zooming distance is reached, then zoom out automatically
        if (transform.position.y < minHeight)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }

        // if maximum zooming distance is reached, then zoom in automatically
        if (transform.position.y > maxHeight)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }

    void RotateAroundPoint()
    {
        // if the 1st and 2nd mouse buttons is held down, then you can move your mouse horizontal to rotate the camera around a point

        // defining a reference for the horizontal and vertical movement of the mouse
        float horizontalMovement = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0) & Input.GetMouseButton(1))
        {
            player.transform.RotateAround(focalPoint.transform.position, new Vector3(0, 1, 0), horizontalMovement * rotateSpeed * Time.deltaTime);
        }
    }

    void AltCameraMovement()
    {
        // defining a reference for the horizontal and vertical movement of the mouse
        float horizontalMovement = Input.GetAxis("Mouse X");
        float verticalMovement = Input.GetAxis("Mouse Y");

        // move the camera via holding down the scroll wheel, versus just using the wasd keys
        // if the player is above a certain height, then increase the movement speed
        if (Input.GetMouseButton(2) & transform.position.y > increasedSpeedHeight)
        {
            player.transform.Translate(-horizontalMovement * Time.deltaTime * 40, 0, -verticalMovement * Time.deltaTime * 40);
        }
        else if (Input.GetMouseButton(2))
        {
            player.transform.Translate(-horizontalMovement * Time.deltaTime * 30, 0, -verticalMovement * Time.deltaTime * 30);
        }
    }
}
