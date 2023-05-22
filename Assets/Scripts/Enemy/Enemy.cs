using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {   
        var damageable = other.gameObject.GetComponent<ITakeDamage>();
        damageable?.TakeDamage(damage);
        Destroy(gameObject);
    }
}
