using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorNode : MonoBehaviour
{
    public List<GameObject> LootNodes;
    public GameObject Door;

    private SpriteRenderer floorSR;
   

    // Start is called before the first frame update
    void Start()
    {
        floorSR = this.gameObject.GetComponent<SpriteRenderer>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Loot")
        {
            if(!LootNodes.Contains(collision.gameObject))
            {
                LootNodes.Add(collision.gameObject);
            }
           
            if(LootNodes.Count == 5)
            {
                floorSR.color = Color.green;
                Door.SetActive(false);
            }
        }
    }
}
