using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform barrel;
    
    public GameObject projectilePrefab;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(projectilePrefab, barrel.transform.position, barrel.rotation);
            
        }
    }
}
