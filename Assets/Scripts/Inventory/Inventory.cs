using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventory = new();

    public void AddItemToInventory(GameObject item)
    {
        inventory.Add(item);
    }
}
