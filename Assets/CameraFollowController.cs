using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{

    public Transform CameraTarget;

    public Vector3 OffsetVector; 

    public float DistanceFromPlayer = 5f;

    [Range(1, 20)]
    public float ScrollSpeed = 2f;

    MouseInputWrapper _MouseInputWrapper;

    // Use this for initialization
    void Start()
    {

        _MouseInputWrapper = CameraTarget.gameObject.GetComponent<MouseInputWrapper>();

    }

    // Update is called once per frame
    void Update()
    {
        //If Ctrl is pressed , dont move the camera
        if (Input.GetKey(KeyCode.LeftControl))
            return;

        //Zoom in/out with scroll wheel
        var Scroll = Input.GetAxis("Mouse ScrollWheel");
        DistanceFromPlayer -= Scroll * ScrollSpeed;
        //Direction Vector Towards Player
        var VectorTowardsPlayer = transform.localPosition;


        //If right mouse button is pressed , dont move the camera
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(CameraTarget.position, CameraTarget.right, -_MouseInputWrapper.Delta.y);
            transform.RotateAround(CameraTarget.position, CameraTarget.up, _MouseInputWrapper.Delta.x);           
            transform.LookAt(CameraTarget.position);
        }


        //On right mouse button release , reset the camera position
        if (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localRotation = Quaternion.identity;
            transform.localPosition = OffsetVector * (DistanceFromPlayer + 1);


        }


        transform.RotateAround(CameraTarget.position, CameraTarget.right, -_MouseInputWrapper.Delta.y);
        KeepDistance();
        transform.LookAt(CameraTarget.position);


    }

    void KeepDistance()
    {
        transform.localPosition = (transform.localPosition.normalized) * (OffsetVector.magnitude + DistanceFromPlayer);
    }

}
