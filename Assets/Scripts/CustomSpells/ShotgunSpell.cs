using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSpell : BaseSpell
{
    // Start is called before the first frame update
    public float spread = 20f;
    override public void Shoot()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject spell = Instantiate(spellData.projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = Quaternion.AngleAxis(Random.Range(-spread/2, spread/2), Vector3.forward) * (mousePos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * spellData.projectileForce;
            spell.GetComponent<TestProjectile>().damage = Random.Range(spellData.maxDamage, spellData.minDamage) + PlayerStats.playerStats.damageModifierAdditive;
        }
    }
}
