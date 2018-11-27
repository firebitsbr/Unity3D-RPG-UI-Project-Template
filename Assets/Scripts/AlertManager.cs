using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlertManager : MonoBehaviour {

    public PlayerClass PlayerClass;
    public static Queue<AlertText> Alerts = new Queue<AlertText>();
    public GameObject AlertPrefab;

    public AnimationCurve TextOpacityAnimation;

	// Update is called once per frame
	void LateUpdate () {
		
        if(Alerts.Count != 0)
        {
            var CurrentAlert = Alerts.Dequeue();
            StartCoroutine(ShowAlertMessage(CurrentAlert));
        }
	}

    public static void AddAlertToQueue(AlertText alert)
    {
        Alerts.Enqueue(alert);
    }

    public IEnumerator ShowAlertMessage(AlertText CurrentAlert)
    {
        var CurrentTime = 0f;

        var tmp = Instantiate(AlertPrefab, transform.GetChild(0).transform);
        tmp.GetComponent<Text>().text = CurrentAlert.AlertMessage;

        while (CurrentTime < CurrentAlert.AlertDuration)
        {
            CurrentTime += Time.deltaTime;
        
            var Fraction = (CurrentTime / CurrentAlert.AlertDuration);
            var TextColor = CurrentAlert.GetAlertTextColor();
            TextColor.a = TextOpacityAnimation.Evaluate(Fraction);

            tmp.GetComponent<Text>().color = TextColor;

            yield return null;
        }

        Destroy(tmp);

        yield return null;
    }



}
