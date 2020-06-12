﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Camera mainCam;
    
    public float thrust = 80f;
    private float originalThrust;
  
    private Rigidbody2D rb2D;
    private float addangle = 180;
    
    private SpriteRenderer SR;

    public enum ControlOptions {AD, WS, WASD};
    public ControlOptions CO = ControlOptions.AD ;

    public static bool IsCloaking = false;
    private Color32 originalColor = new Color32(255, 255, 255, 255);
    private Color32 cloakColor = new Color32(255, 255, 255, 80);

    private bool ADforward = true;
    private bool WSforward = false;
    private bool traditionalWASD = false;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        originalThrust = thrust;
        rb2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(Input.mousePosition.y - mainCam.WorldToScreenPoint(transform.position).y, Input.mousePosition.x - mainCam.WorldToScreenPoint(transform.position).x);
        
        // Rotate Object
        float AngleDeg = (180 / Mathf.PI) * AngleRad + addangle;        
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        

        if(AngleDeg >= 180 && AngleDeg < 270)
        {
           SR.flipY = true;
        }  
        else if(AngleDeg >= 90 && AngleDeg < 180)  
        {
           SR.flipY = true;
        }   
        else
        {
           SR.flipY = false;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            IsCloaking = !IsCloaking;
        }
        CloakAbility();



        switch (CO)
        {
            case ControlOptions.AD: 
            ADforward = true;
            WSforward = false;
            traditionalWASD = false; 
            break;

            case ControlOptions.WS: 
            ADforward = false;
            WSforward = true;
            traditionalWASD = false; 
            break;
            
            case ControlOptions.WASD:
            ADforward = false;
            WSforward = false;
            traditionalWASD = true; 
            break;

        }
       
    }

    void CloakAbility()
    {
        if(IsCloaking)
        {
            SR.color = Color.Lerp(SR.color, cloakColor, 0.08f);
        }
        else
        {
            SR.color = Color.Lerp(SR.color, originalColor, 0.08f);
        }
    }



    void FixedUpdate()
    {
       
        if(ADforward)
        {
           //transform.position += transform.right * Input.GetAxis("Horizontal") * thrust * Time.deltaTime
           rb2D.AddForce(transform.right * Input.GetAxis("Horizontal") * thrust, ForceMode2D.Force);
            
        }
        else if(WSforward)
        {
           
           rb2D.AddForce(-transform.right * Input.GetAxis("Vertical") * thrust, ForceMode2D.Force);

        }
        else if(traditionalWASD)
        {
          
             rb2D.AddForce(Vector2.right * Input.GetAxis("Horizontal") * thrust, ForceMode2D.Force);
             rb2D.AddForce(Vector2.up * Input.GetAxis("Vertical") * thrust, ForceMode2D.Force);


        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
           
            thrust = thrust * 0.995f;  
        }
        else
        {
             thrust = originalThrust;
        }
    
      

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyProjectile")
        {
            Destroy(col.gameObject);
        }
    }
}
