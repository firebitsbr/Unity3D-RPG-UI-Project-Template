using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{

    Rigidbody _rb;
    [Range(0, 5)]
    public float RotationSpeed;

    MouseInputWrapper _MouseInputWrapper;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _MouseInputWrapper = GetComponent<MouseInputWrapper>();
    }

    // Update is called once per frame
    void Update()
    {

        //If left Ctrl or right mouse button is press dont do anything
        if (Input.GetKey(KeyCode.LeftControl))
            return;

        if (Input.GetMouseButton(1))
            return;


        //Else rotate Player
        var CurrentRotation = _rb.rotation.eulerAngles;

        CurrentRotation.y += _MouseInputWrapper.Delta.x;
        _rb.rotation = Quaternion.Euler(CurrentRotation);



    }


}
