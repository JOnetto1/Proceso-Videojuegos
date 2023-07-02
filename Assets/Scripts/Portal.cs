using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public Direction DirectionOfEntry;
    public int OriginScene = -1;
    public bool isActive = true;
    public bool isOnCoolDown = false;
    public bool isLinked = false;
    public Portal LinkedPortal;

    public static void LinkPortals(Portal p1, Portal p2)
    {
        p1.LinkedPortal = p2;
        p1.isLinked = true;
        p2.LinkedPortal = p1;
        p2.isLinked = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOnCoolDown)
        {
            return;
        }

        if (collision.tag == "Player")
        {
            MapController.instance.TravelToPortal(LinkedPortal);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isOnCoolDown)
            {
                isOnCoolDown = false;
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
