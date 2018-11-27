using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollowController : MonoBehaviour {

    public Transform CameraTarget;

    Vector3 LastMousePos;

    [Range(1 , 10)]
    public float ForwardOffset = 1;

    [Range(1, 10)]
    public float UpOffset = 1;

    [Range(1 , 5)]
    public float ScrollSpeed = 2f;

	// Use this for initialization
	void Start () {

        LastMousePos = Input.mousePosition;
    }
	
	// Update is called once per frame
	void Update () {

        ForwardOffset -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        UpOffset -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;

        var CameraOffset = (-1 * ForwardOffset * CameraTarget.transform.forward) + (Vector3.up * UpOffset);

        var Rotation = MouseDelta();

        if (!Input.GetKey(KeyCode.LeftControl))
        {


            transform.position = CameraTarget.position + CameraOffset;
            //transform.RotateAround(CameraTarget.position, CameraTarget.right, Rotation.y);

        }

        else
        {
            

            transform.RotateAround(CameraTarget.position, CameraTarget.up, Rotation.x );
            transform.RotateAround(CameraTarget.position, CameraTarget.right, Rotation.y );
            
        }

        transform.LookAt(CameraTarget.position);

    }

    

    public Vector3 MouseDelta()
    {
        var Delta = Input.mousePosition - LastMousePos;

        LastMousePos = Input.mousePosition;

        return Delta;
    }


}
