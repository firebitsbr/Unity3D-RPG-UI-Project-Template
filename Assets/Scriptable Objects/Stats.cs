using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsObject", menuName = "Create Object/Stats")]
public class Stats : ScriptableObject {


    public int Health;
    public int MaxHealth;

    public int Resource;
    public int MaxResource;

    public ResourceType ResourcesType;

    public Color ResourcesToColor()
    {
        switch (this.ResourcesType)
        {
            case ResourceType.Rage:
                return Color.red;
            case ResourceType.Mana:
                return Color.blue;
            case ResourceType.Energy:
                return Color.yellow;
            case ResourceType.Wind:
                return Color.gray;
            default:
                return Color.white;
        }
    }
	
}

public enum ResourceType
{
    Rage , Mana , Energy , Wind
}

