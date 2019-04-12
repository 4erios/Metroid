using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Controller_Missile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missilePrefab;
    public Transform canon;
    public Animator anim;

    public colorChangeScript ScriptChangeColor;
    private bool StateMissile = false; 
    
    public int missileNumber = 0;
    static public bool BaseState {get; private set;}

    private void Awake()
    {
        BaseState = true;
    }

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

                ScriptChangeColor.MissileColors();
                Debug.Log("Mode Missile ON");
           }
           else
           {
                BaseState = true;
                StateMissile = false;

                ScriptChangeColor.NormalBullet();

                Debug.Log("Mode Tir ON");
           }
        }

        if (Input.GetButtonDown("Fire") && StateMissile == true && missileNumber > 0 && anim.GetBool("Boule_State") == false)
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
