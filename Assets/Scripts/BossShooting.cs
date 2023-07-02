using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public Transform player;
    public float projectileForce;
    public float smallCooldown;
    public float bigCooldown;
    public float cooldown;
    public int burst;
    public int currentBurst;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        StartCoroutine(ShootPlayer());
        currentBurst = burst - 1;
        cooldown = smallCooldown;
    }

    IEnumerator ShootPlayer()
    {
        if (currentBurst > 0)
        {
            cooldown = smallCooldown;
            currentBurst--;
        }
        else
        {
            cooldown = bigCooldown;
            currentBurst = burst - 1;
        }
        yield return new WaitForSeconds(cooldown);
        if (player != null && Vector3.Distance(player.position, this.transform.position) < 50f)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<EnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
        }
        StartCoroutine(ShootPlayer());
    }
}
