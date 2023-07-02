using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public GameObject player;
    public float health;
    public float damageModifierAdditive = 0;
    public float maxHealth;
    public float movSpeed;

    private PlayerMovement playerMovement;
    private BaseSpell currentSpell;


    public void SetMovSpeed(float movSpeed)
    {
        this.movSpeed = movSpeed;
        playerMovement.speed = movSpeed;
    }

    void Awake()
    {
        if(playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        currentSpell = FindObjectOfType<BaseSpell>();
        health = maxHealth;    
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    public void AddVentaja(Item.Ventaja ventaja)
    {
        switch(ventaja)
        {
            case Item.Ventaja.MAS_DANO:
                damageModifierAdditive += 10;
                break;
            case Item.Ventaja.MAS_VIDA:
                health += 25f;
                maxHealth += 25f;
                break;
            case Item.Ventaja.BURST:
                Destroy(currentSpell);
                BaseSpell newSpell = player.AddComponent<ShotgunSpell>();
                newSpell.spellData = Resources.Load<SpellData>("ShotgunSpellData");
                currentSpell = newSpell;
                break;
        }
    }

    public void AddDesventaja(Item.Desventaja desventaja)
    {
        switch(desventaja)
        {
            case Item.Desventaja.MENOS_DANO:
                damageModifierAdditive -= 5;
                break;
            case Item.Desventaja.MENOS_VEL:
                SetMovSpeed(movSpeed - 2);
                break;
            case Item.Desventaja.MENOS_VIDA:
                health -= 15f;
                maxHealth -= 15f;
                break;
        }
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
    }

    private void CheckOverheal()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            Destroy(player);
        }
    }
}
