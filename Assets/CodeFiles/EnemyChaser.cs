using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public GameObject Player;
    private int health = 1;
    public float chaseSpeed = 100f;
    private Rigidbody2D rb2d;
    //private float addangle = 180;
    private SpriteRenderer SR;
    //public float timeCount = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }

        transform.right = -(Player.transform.position - transform.position);
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, chaseSpeed * Time.deltaTime);

        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            SR.flipY = true;
        }
        else
        {
            SR.flipY = false;
        }
        
        /*
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(transform.position.y - Player.transform.position.y, transform.position.x - Player.transform.position.x);

        // Rotate Object
        float AngleDeg = (180 / Mathf.PI) * AngleRad; // + addangle;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
         */    
        //rb2d.AddForce(Vector2.left * chaseSpeed, ForceMode2D.Force);
        //Debug.Log(AngleDeg);

       
    }

    private int OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "projectile")
        {
            health--;
            Destroy(col.gameObject);
        }

        return health;

    }
}
