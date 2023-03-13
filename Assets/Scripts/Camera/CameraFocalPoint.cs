using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocalPoint : MonoBehaviour
{
    private GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void LateUpdate()
    // new Vector3(3, 0, 3.56f)
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x, 0, transform.position.z), new Quaternion(-40, transform.rotation.y, 0, 0));
    }
}
