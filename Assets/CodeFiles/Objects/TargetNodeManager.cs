using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNodeManager : MonoBehaviour
{
    public List<SpriteRenderer> SRnodes;
    public GameObject Door;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < SRnodes.Count; i++)
        {
            if(SRnodes[i].color == Color.green)
            {
                SRnodes.RemoveAt(i);
               
            }

            if (SRnodes.Count == 0)
            {
                Door.SetActive(false);
            }
        }
    }
}
