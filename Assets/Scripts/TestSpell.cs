using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
           GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
           Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           Vector2 direction = mousePos - transform.position;
           spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
        }    
    }
}
