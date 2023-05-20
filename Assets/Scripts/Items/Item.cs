using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IGetPickedUp
{
    public void PickUpItem(Inventory inventory)
    {
        inventory.AddItemToInventory(this.gameObject);
        Debug.Log(this.gameObject.name + " was picked up.");
        this.gameObject.SetActive(false);
    }
}
