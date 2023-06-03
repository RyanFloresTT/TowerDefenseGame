using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrikeDamage : MonoBehaviour
{
    public float Damage { private get; set; }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        enemy?.TakeDamage(Damage);  
    }
}
