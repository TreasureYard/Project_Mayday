using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public List<GameObject> LootInventory;
    private int maxWeight = 4;
    private int childcount;

    // Start is called before the first frame update
    void Start()
    {
        LootInventory = new List<GameObject>(maxWeight);
    }

    // Update is called once per frame
    void Update()
    {
        
        childcount = this.gameObject.transform.childCount;
        if (childcount > maxWeight)
        {
            if(this.gameObject.transform.GetChild(childcount - 1).TryGetComponent<Loot>(out var loot))
            {
                loot.OutOfSpace();
            }
        }
        else if(childcount != 0)
        {
            if (this.gameObject.transform.GetChild(childcount - 1).TryGetComponent<Loot>(out var loot))
            {
                loot.DropLoot();
            }
        }
       
        
    }
}
