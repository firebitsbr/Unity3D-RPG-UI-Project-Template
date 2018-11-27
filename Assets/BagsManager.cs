using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagsManager : MonoBehaviour {

    public PlayerClass PlayerClass;

    public GameObject BagPrefab;
    // Use this for initialization
    void Start () {
		
        foreach(var Bag in PlayerClass.PlayerObject.Bags)
        {
            var tmpBag = Instantiate(BagPrefab, transform);
            tmpBag.GetComponent<BagManager>().Bag = Bag;
            tmpBag.GetComponent<BagManager>().Manager = this;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
