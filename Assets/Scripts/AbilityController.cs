
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour {

    public AbilityManager AbilityManager;

    public Ability AbilityData;

    Image Icon;
    Button AbilityButton;

    float CurrentCooldown;

	// Use this for initialization
	void Start () {

        AbilityButton = GetComponent<Button>();
        Icon = AbilityButton.image;

        CurrentCooldown = AbilityData.CoolDown;
        Icon.sprite = AbilityData.Icon;

        AbilityButton.onClick.AddListener(() =>
        {
            if(AbilityManager.PlayerClass.PlayerObject.PlayerStats.Resource >= AbilityData.Cost)
            {
                AbilityManager.PlayerClass.PlayerObject.PlayerStats.Resource -= AbilityData.Cost;

                AbilityButton.interactable = false;
                AbilityData.OnUse();
            
                StartCoroutine(setOnCoolDown());
            }
            else
            {
                var tmp = ScriptableObject.CreateInstance<AlertText>();
                tmp.AlertDuration = 2;
                tmp.AlertTextType = AlertTextType.Info;
                tmp.AlertMessage = "Not Enough " + AbilityManager.PlayerClass.PlayerObject.PlayerStats.ResourcesType.ToString();

                AlertManager.AddAlertToQueue(tmp);
            }
        });
	}

    private IEnumerator setOnCoolDown()
    {
        CurrentCooldown = 0;

        while (CurrentCooldown < AbilityData.CoolDown)
        {
            CurrentCooldown += Time.deltaTime;

            Icon.fillAmount = (CurrentCooldown / AbilityData.CoolDown);

            yield return null;

        }

        Icon.fillAmount = 1;
        CurrentCooldown = AbilityData.CoolDown;
        AbilityButton.interactable = true;

        yield return null;
    }
}
