using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputWrapper : MonoBehaviour {

    Vector3 LastMousePos;

    public Vector3 Delta;

    // Use this for initialization
    void Start () {

        LastMousePos = Input.mousePosition;
    }
	
	// Update is called once per frame
	void Update () {

        MouseDelta();

    }

    void MouseDelta()
    {
        var Delta = Input.mousePosition - LastMousePos;

        LastMousePos = Input.mousePosition;

        this.Delta = Delta;
    }
}
