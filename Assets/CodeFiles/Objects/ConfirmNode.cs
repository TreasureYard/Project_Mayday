using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ConfirmNode : MonoBehaviour
{
    SpriteRenderer SR;
    public GameObject text;
    private void Start()
    {
        SR = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(text.activeSelf == true)
            {
                text.SetActive(false);
            }
            SR.color = Color.green;
        }
    }
}
