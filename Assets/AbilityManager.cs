using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour {

    public PlayerObject PlayerObject;
    public GameObject AbilityPrefab;

	// Use this for initialization
	void Start () {
		
        foreach(var ability in PlayerObject.Abilities)
        {
            var tmp = Instantiate(AbilityPrefab, this.transform);
            var AbController = tmp.transform.GetChild(0).GetComponent<AbilityController>();
            AbController.AbilityData = ability;
            AbController.AbilityManager = this;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
