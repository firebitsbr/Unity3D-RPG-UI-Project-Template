using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfilePicture : MonoBehaviour {

    public RenderTexture ProfilePicture;
    public Camera _cam;

	// Use this for initialization
	void Start () {
        
        ProfilePicture = new RenderTexture(300, 300, 24);
        ProfilePicture.enableRandomWrite = true;
        ProfilePicture.Create();

        _cam.targetTexture = ProfilePicture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
