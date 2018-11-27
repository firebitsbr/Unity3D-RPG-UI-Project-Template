
using UnityEngine;
using UnityEngine.UI;

public class HealthManaController : MonoBehaviour {

    public PlayerClass PlayerClass;

    public Image HealthBar;
    public Image ResourcesBar;

    public Text HealthValue;
    public Text ResourcesValue;


	void Start () {

        ResourcesBar.color = PlayerClass.PlayerObject.PlayerStats.ResourcesToColor();

    }
	
	void Update () {

        HealthValue.text = "Health : " + PlayerClass.PlayerObject.PlayerStats.Health + " / " + PlayerClass.PlayerObject.PlayerStats.MaxHealth;
        ResourcesValue.text = PlayerClass.PlayerObject.PlayerStats.ResourcesType.ToString() + " : " + PlayerClass.PlayerObject.PlayerStats.Resource + " / " + PlayerClass.PlayerObject.PlayerStats.MaxResource;

        var HealthFrac = Mathf.Clamp01(PlayerClass.PlayerObject.PlayerStats.Health /(float)PlayerClass.PlayerObject.PlayerStats.MaxHealth);
        var ResourceFrac = Mathf.Clamp01(PlayerClass.PlayerObject.PlayerStats.Resource /(float)PlayerClass.PlayerObject.PlayerStats.MaxResource);


        HealthBar.GetComponent<RectTransform>().localScale = new Vector3(HealthFrac, 1, 1);
        ResourcesBar.GetComponent<RectTransform>().localScale = new Vector3(ResourceFrac, 1, 1);

    }
}
