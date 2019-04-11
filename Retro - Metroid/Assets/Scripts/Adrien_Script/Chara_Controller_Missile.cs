using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Controller_Missile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missilePrefab;
    public Transform canon;
    public Animator anim;

 



    public float weaponRange = 5f;
    float nextFire = 0.5f;
    public float damage = 100f;
    public int missileNumber = 0;
   


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Swith_Weapo"))
        {
            anim.SetBool("State Missile", true);
         
        }


     
        if (Input.GetButtonDown("Fire") && anim.GetBool("State Missile") == true)
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
