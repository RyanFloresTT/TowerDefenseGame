using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PickupItemsInRadius : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<IGetPickedUp>();
        var parent = this.gameObject.GetComponentInParent<Inventory>();
        if (item == null || parent == null) return;
        item.PickUpItem(parent);
    }
}
