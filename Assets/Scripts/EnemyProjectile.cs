using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Enemy"))
        {
            if(collision.CompareTag("Player"))
            {
                PlayerStats.playerStats.DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
