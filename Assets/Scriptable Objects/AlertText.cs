
using UnityEngine;

public class AlertText : ScriptableObject {

    public string AlertMessage;
    public float AlertDuration;
    public AlertTextType AlertTextType;

    public Color GetAlertTextColor()
    {
        switch (AlertTextType)
        {
            case AlertTextType.Danger:
                return Color.red;
            case AlertTextType.Info:
                return Color.cyan ;
            case AlertTextType.Success:
                return Color.green ;
            case AlertTextType.Alert:
                return Color.magenta ;
            case AlertTextType.CriticalHit:
                return Color.yellow ;
            default:
                return Color.white ;
        }
    }
}

public enum AlertTextType
{
    Danger , Info , Success , Alert , CriticalHit
}
