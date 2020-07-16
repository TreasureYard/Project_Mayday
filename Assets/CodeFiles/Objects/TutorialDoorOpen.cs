using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoorOpen : MonoBehaviour
{
    public List<GameObject> nodes;
    public GameObject Door;
    
  

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < nodes.Count; i++)
        {
            if(nodes[i].gameObject.GetComponent<SpriteRenderer>().color == Color.green)
            {
                nodes.RemoveAt(i);
                if(nodes.Count == 0)
                {
                    Door.SetActive(false);
                }
            }
            
            
        }
    }
}
