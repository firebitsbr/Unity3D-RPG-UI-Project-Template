using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {

    public BagManager Manager;

    public ConsumableItem ConsumableItemData;

    Image Icon;
    Button ItemButton;


    // Use this for initialization
    void Start()
    {
        SetItemSettings();
    }

    public void SetItemSettings()
    {
        ItemButton = GetComponent<Button>();

        if (ConsumableItemData == null)
        {
            ItemButton.image.color = Color.blue;
            return;
        }

       
        ItemButton.image.sprite = ConsumableItemData.Icon;
       

        ItemButton.onClick.AddListener(() =>
        {
            ConsumableItemData.Consume();
            Manager.Bag.itemsList.Remove(ConsumableItemData);
            Manager.RefreshBag();

        });
    }

    


}
