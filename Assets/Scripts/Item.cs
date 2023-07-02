using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update

    public string advantaje;
    public string disadvantaje;
    public Ventaja ventaja;
    public Desventaja desventaja;
    public ItemSelector itemSelector;

    public enum Ventaja
    {
        MAS_DANO,
        BURST,
        MAS_VIDA
    }

    public enum Desventaja
    {
        MENOS_DANO,
        MENOS_VEL,
        MENOS_VIDA
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats.playerStats.AddVentaja(ventaja);
            PlayerStats.playerStats.AddDesventaja(desventaja);
        }
        itemSelector.ItemSelected();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
