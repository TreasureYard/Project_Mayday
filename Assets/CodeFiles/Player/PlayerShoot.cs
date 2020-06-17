using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform barrel;

    public int chargeupMax = 100;
    private int currentchargeup;
    public GameObject projectilePrefab;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            charging();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            zerocharge();
        }
    }

    int charging()
    {
        currentchargeup = currentchargeup + 1;
        if (currentchargeup == chargeupMax)
        {
            Instantiate(projectilePrefab, barrel.transform.position, barrel.rotation);
            zerocharge();
        }
        return currentchargeup;
    }

    int zerocharge()
    {
        currentchargeup = 0;
        return currentchargeup;
    }
}
