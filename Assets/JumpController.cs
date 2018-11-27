using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {

    Rigidbody _rb;
    [Range(1 , 15)]
    public float JumpForce = 2;
    public float DragDownForce = 0.4f;
    [Range(1 , 3)]
    public float DistanceFromGround = 1.3f;
    public bool CanJump = true;

    int LayerNumber;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();

        LayerNumber = LayerMask.GetMask("Ground");
    }
	
	// Update is called once per frame
	void Update () {

        JumpCheck();

        if (CanJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            }
        }

        else
        {
            var TemporaryVel = _rb.velocity;
            TemporaryVel.y -= DragDownForce;

            _rb.velocity = TemporaryVel;
        }

	}


    void JumpCheck()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(transform.position , transform.up * -1 , out hit , DistanceFromGround, LayerNumber))
        {
            CanJump = true;
            return;
        }

        CanJump = false;
    }

}
