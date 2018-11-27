using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour {

    Rigidbody _rb;
    [Range(0 , 5)]
    public float RotationSpeed;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if(!Input.GetKey(KeyCode.LeftControl))
        { 

            var CurrentRotation = _rb.rotation.eulerAngles;

            CurrentRotation.y += RotationSpeed * this.MouseDelta().x;
            _rb.rotation = Quaternion.Euler(CurrentRotation);

        }
    }


}
