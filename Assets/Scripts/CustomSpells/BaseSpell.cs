using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpell : MonoBehaviour
{
    public SpellData spellData;
    private float currentCooldown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentCooldown <= 0)
        {
            currentCooldown = spellData.cooldown;
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if(currentCooldown < 0)
        {
            currentCooldown = 0;
        }
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.fixedDeltaTime;
        }
    }

    public abstract void Shoot();
}
