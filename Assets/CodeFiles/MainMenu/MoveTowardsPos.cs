using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPos : MonoBehaviour
{
    public GameObject btnPos;
    private RectTransform btnrec;
    private void Start()
    {
        btnrec = btnPos.GetComponent<RectTransform>();
    }

    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            RectTransform myRectTransform = GetComponent<RectTransform>();

            if (myRectTransform.anchoredPosition.x >= btnrec.anchoredPosition.x)
            {
                
                myRectTransform.anchoredPosition += Vector2.left * 800 * Time.smoothDeltaTime;
                Debug.Log("a");
            } 
           

        }
    }
}
