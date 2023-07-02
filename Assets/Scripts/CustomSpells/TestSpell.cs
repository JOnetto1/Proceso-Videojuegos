using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : BaseSpell
{

    override public void Shoot()
    {
        GameObject spell = Instantiate(spellData.projectile, transform.position, Quaternion.identity);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;
        Vector2 direction = (mousePos - myPos).normalized;
        spell.GetComponent<Rigidbody2D>().velocity = direction * spellData.projectileForce;
        spell.GetComponent<TestProjectile>().damage = Random.Range(spellData.maxDamage, spellData.minDamage) + PlayerStats.playerStats.damageModifierAdditive;    
    }
}
