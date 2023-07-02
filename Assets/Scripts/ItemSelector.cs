using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{

    public void ItemSelected()
    {
        Item[] children = GetComponentsInChildren<Item>();
        for(int i = 0; i < children.Length; i++)
        {
            Destroy(children[i].gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
