
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour {

    public BagsManager Manager;

    public Bag Bag;

    public GameObject ItemPrefab;

    public Transform BagContainer;

    public InputField ItemsSearch;

	// Use this for initialization
	void Start () {



        ItemsSearch.onValueChanged.AddListener((query)=>
        {
            if(Bag.itemsList.Count == 0)
            {
                return;
            }

            if(string.IsNullOrEmpty(query.Trim()))
            {
                RefreshBag();
                return;
            }

            var searchRes = Bag.itemsList.Where(x => x != null).Where(x => x.Name.Trim().ToLower().Contains(query.ToLower())).ToList();

            Debug.Log(searchRes.Count);

        });

        ShowItemList(Bag.itemsList);

    }
	
	public void ShowItemList(List<ConsumableItem> list)
    {
        
        foreach (Transform child in BagContainer)
        {
            Destroy(child.gameObject);
        }

        for(int i = 0; i < Bag.Capacity; i++)
        {
            var tmp = Instantiate(ItemPrefab, BagContainer);

            if ( i < list.Count)
            { 
                tmp.transform.GetChild(0).GetComponent<ItemController>().ConsumableItemData = list[i];
            }

            tmp.transform.GetChild(0).GetComponent<ItemController>().Manager = this;
        }
    }

    public void RefreshBag()
    {
        ShowItemList(Bag.itemsList);
    }


}
