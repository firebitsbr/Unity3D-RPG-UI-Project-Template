using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerObject", menuName = "Create Object/PlayerObject")]
public class PlayerObject : ScriptableObject {

    public List<Ability> Abilities;
    public Stats PlayerStats;
    public List<Bag> Bags;

}
