using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTropper : MonoBehaviour
{
    public GameObject Player;
    public GameObject Arm;
    private SpriteRenderer SR;
    private SpriteRenderer SRarm;
    public PlayerDetect PD;
    // Start is called before the first frame update
    void Start()
    {
        SRarm = Arm.GetComponent<SpriteRenderer>();
        SR = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(Arm.transform.position.y- Player.transform.position.y, Arm.transform.position.x - Player.transform.position.x);

        // Rotate Object
        float AngleDeg = (180 / Mathf.PI) * AngleRad; //+ addangle;


        if (AngleDeg >= -35 && PD.playerDetected && Vector3.Distance(Player.transform.position, transform.position) < 100) 
        {
            Arm.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }
        
       
       
    }

    
}
