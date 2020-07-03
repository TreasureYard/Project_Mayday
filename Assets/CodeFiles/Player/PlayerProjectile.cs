using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
       // Invoke("destroySelf", 100f);
    }

    // Update is called once per frame
    void Update()
    {
       rb2d.AddForce(-transform.right * speed, ForceMode2D.Force);
    }

    void destroySelf()
    {
        Destroy(gameObject);
    }
}
