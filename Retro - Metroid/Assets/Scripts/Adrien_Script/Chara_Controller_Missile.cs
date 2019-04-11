using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Controller_Missile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missilePrefab;
    public Transform canon;
    public Animator anim;
    public bool StateMissile = false; 
    public bool BaseState = true;
    public int missileNumber = 0;
   


    // Update is called once per frame
    void Update()
    {
        // Switch entre tir et missile
        if (Input.GetButtonDown("Switch_Weapon"))
        {
           if (BaseState == true)
            {
                StateMissile = true;
                BaseState = false;
                Debug.Log("Mode Missile ON");

            }
           else
            {


                BaseState = true;
                StateMissile = false;
                Debug.Log("Mode Tir ON");
            }

        
         
        }


     
        if (Input.GetButtonDown("Fire") && StateMissile == true && missileNumber > 0)
        {
            fireMissile();

        }


    }


    void fireMissile ()
    {
        missileNumber--;
        Instantiate(missilePrefab, canon.position, canon.rotation);
       

    }
}
