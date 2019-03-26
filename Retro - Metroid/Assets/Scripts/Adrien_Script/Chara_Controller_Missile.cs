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
    PlayerMovement c_movement;



    void Awake()
    {
        c_movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire") && Time.time > nextFire)
        {

            raycastMissile(Vector2(canon), 

        }

    }


    void fire ()
    {

        missilePos = transform.position;
        Vector2 2 canonPosition = new Vector2 ()


    }
}
