using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameObject Player;
    public LootManager LM;
    private Rigidbody2D rb2d;
    private bool followplayer;
    public float objectspeed = 1000;
    private void Start()
    {
        LM = Player.transform.GetChild(1).GetComponent<LootManager>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1) && Vector2.Distance(Player.transform.position, transform.position) < 15)
        {
            //transform.position = Player.transform.GetChild(1).transform.position;
            rb2d.gravityScale = 0;
            followplayer = true;
            addLoot();

            transform.parent = Player.transform.GetChild(1).transform; 

            
          
        }
    }

    private void FixedUpdate()
    {
        if(followplayer)
        {
            rb2d.AddForce((Player.transform.GetChild(1).transform.position - transform.position).normalized * objectspeed * Time.deltaTime, ForceMode2D.Force);
            
            Debug.Log("moving");
        }
    }

    public void OutOfSpace()
    {
        rb2d.gravityScale = 1;
        followplayer = false;
        transform.parent = null;
        LM.LootInventory.Remove(this.gameObject);
        Debug.Log("Out of Space");
    }

    public void DropLoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.gravityScale = 1;
            followplayer = false;
            transform.parent = null;
            LM.LootInventory.Remove(this.gameObject);
            Debug.Log("Dropped");
        }
    }

    void addLoot()
    {

        LM.LootInventory.Add(this.gameObject);
    }
}
