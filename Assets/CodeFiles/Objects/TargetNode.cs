using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNode : MonoBehaviour
{
    SpriteRenderer SR;

    private void Start()
    {
        SR = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            SR.color = Color.green;
        }
        Destroy(collision.gameObject);
    }


}
