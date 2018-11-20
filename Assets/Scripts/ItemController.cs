using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {

    public BagManager Bag;

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
        Icon = ItemButton.image;

        Icon.sprite = ConsumableItemData.Icon;

        ItemButton.onClick.AddListener(() =>
        {
            ConsumableItemData.Consume();
            Bag.PlayerObject.Items.Remove(ConsumableItemData);
            Destroy(this.transform.parent.gameObject);

        });
    }


}
