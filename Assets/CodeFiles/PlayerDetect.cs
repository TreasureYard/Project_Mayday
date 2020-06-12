using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public bool playerDetected;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerDetected = true;
            /*
            if(PlayerMove.IsCloaking)
            {
                playerDetected = false;
            }
            else
            {
                playerDetected = true;
            }
            */

        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            playerDetected = false;
        }

      
    }
}
