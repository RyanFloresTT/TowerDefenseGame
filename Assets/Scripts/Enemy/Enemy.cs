using UnityEngine;

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
