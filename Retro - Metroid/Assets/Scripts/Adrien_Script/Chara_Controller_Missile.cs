using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Controller_Missile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missilePrefab;
    public Transform canon;


    public float weaponRange = 5f;
    float nextFire = 0.5f;
    public float damage = 100f;
    public int missileNumber = 0;
   




    void Awake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire") && Time.time > nextFire)
        {
            missileNumber--;
            fireMissile();

        }

    }


    void fireMissile ()
    {

        Instantiate(missilePrefab, canon.position, canon.rotation);
       

    }
}
