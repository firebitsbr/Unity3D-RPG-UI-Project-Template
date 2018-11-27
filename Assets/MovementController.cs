using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    Rigidbody _rb;
    [Range(0, 10)]
    public float MovementSpeed = 1;
	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        var sideways = Input.GetAxis("Horizontal") * MovementSpeed  * transform.right;
        var forward = Input.GetAxis("Vertical") * MovementSpeed * transform.forward ;

        var Sum = sideways + forward;

        _rb.velocity = new Vector3(Sum.x, _rb.velocity.y, Sum.z);

	}
}
