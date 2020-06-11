using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTropper : MonoBehaviour
{
    public GameObject Player;
    public GameObject Arm;
    private Animator arm_ac;

    private int health = 1;

    private SpriteRenderer SR;
    private SpriteRenderer SRarm;
    public PlayerDetect PD;
    private Quaternion originalPos_arm;
    //private float timecount = 0.1f;

    
    public Transform barrel;
    private bool IsFire;
    //private float bulletBurst = 0f;
    public float fireDelaytime = 0.5f;
    private bool spottedDelay = true;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        arm_ac = Arm.GetComponent<Animator>();
        originalPos_arm = Arm.transform.rotation;
        SRarm = Arm.GetComponent<SpriteRenderer>();
        SR = GetComponent<SpriteRenderer>();
        StartCoroutine(burstFire());

    }

    // Update is called once per frame
    void Update()
    {
        if(health < 1)
        {
            Destroy(gameObject);
        }
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(Arm.transform.position.y- Player.transform.position.y, Arm.transform.position.x - Player.transform.position.x);

        // Rotate Object
        float AngleDeg = (180 / Mathf.PI) * AngleRad; //+ addangle;


        Vector2 toTarget = (Player.transform.position - transform.position).normalized;

        if (Vector2.Dot(toTarget, -transform.right) > 0 && PD.playerDetected && Vector3.Distance(Player.transform.position, transform.position) < 25)
        {
            

            Arm.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

            IsFire = true;
        }
        else if(Vector2.Dot(toTarget, transform.right) > 0 && !PD.playerDetected && Vector3.Distance(Player.transform.position, transform.position) < 25)
        {
            //Debug.Log(AngleDeg);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            
            IsFire = false;
            SRarm.flipY = true;
            Arm.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
            
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            arm_ac.SetBool("IsFiring", false);
            SRarm.flipY = false;
            IsFire = false;
        }
        
    }

    IEnumerator burstFire()
    {
        while(true)
        {

            
            if (IsFire && spottedDelay)
            {
                yield return new WaitForSeconds(fireDelaytime);
                spottedDelay = false;
               

            }
            else if(IsFire && !spottedDelay)
            {
                
                yield return new WaitForSeconds(2f);

                arm_ac.SetTrigger("IsFiring");
                Instantiate(projectilePrefab, barrel.transform.position, barrel.rotation);
                
                yield return new WaitForSeconds(0.2f);
                //arm_ac.SetTrigger("IsFiring");
                Instantiate(projectilePrefab, barrel.transform.position, barrel.rotation);
                
                yield return new WaitForSeconds(0.2f);
                //arm_ac.SetTrigger("IsFiring");
                Instantiate(projectilePrefab, barrel.transform.position, barrel.rotation);
                arm_ac.SetTrigger("NotFiring");

            }
            yield return null;
        }
       

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
