using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour {

    public PlayerObject PlayerObject;

    public GameObject ItemPrefab;

    public Transform BagContainer;

    public InputField ItemsSearch;

	// Use this for initialization
	void Start () {

        ShowItemList(PlayerObject.Items);

        ItemsSearch.onValueChanged.AddListener((query) =>
        {
            if(string.IsNullOrEmpty(query.Trim()))
            {
                ShowItemList(PlayerObject.Items);
                return;
            }

            ShowItemList(PlayerObject.Items.Where(x => x.Name.Trim().ToLower().Contains(query.ToLower())).ToList());

        });

    }
	
	void ShowItemList(List<ConsumableItem> list)
    {

        foreach (Transform child in BagContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in list)
        {
            var tmp = Instantiate(ItemPrefab, BagContainer);

            tmp.transform.GetChild(0).GetComponent<ItemController>().ConsumableItemData = item;
            tmp.transform.GetChild(0).GetComponent<ItemController>().Bag = this;
        }
    }


}
