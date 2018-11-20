using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManaController : MonoBehaviour {

    public PlayerObject PlayerObject;

    public Image HealthBar;
    public Image ResourcesBar;

    public Text HealthValue;
    public Text ResourcesValue;


	void Start () {

        ResourcesBar.color = PlayerObject.PlayerStats.ResourcesToColor();

    }
	
	void Update () {

        HealthValue.text = "Health : " + PlayerObject.PlayerStats.Health + " / " + PlayerObject.PlayerStats.MaxHealth;
        ResourcesValue.text = PlayerObject.PlayerStats.ResourcesType.ToString() + " : " + PlayerObject.PlayerStats.Resource + " / " + PlayerObject.PlayerStats.MaxResource;

        var HealthFrac = Mathf.Clamp01(PlayerObject.PlayerStats.Health /(float)PlayerObject.PlayerStats.MaxHealth);
        var ResourceFrac = Mathf.Clamp01(PlayerObject.PlayerStats.Resource /(float)PlayerObject.PlayerStats.MaxResource);


        HealthBar.GetComponent<RectTransform>().localScale = new Vector3(HealthFrac, 1, 1);
        ResourcesBar.GetComponent<RectTransform>().localScale = new Vector3(ResourceFrac, 1, 1);

    }
}
