using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BagObject", menuName = "Create Object/BagObject")]
public class Bag : ScriptableObject {

    public int Capacity = 15;
    public List<ConsumableItem> itemsList;
}
