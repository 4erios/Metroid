using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Script : MonoBehaviour
{
    
     Animator AnimExplo;
     public bool Destruct;
    // Start is called before the first frame update
    void Start()
    {
        AnimExplo = GetComponent<Animator>();
        Destruct = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Variable Destruct appelée dans l'Animator
        AnimExplo.SetTrigger("Explosion");

        if (Destruct == true) {

            Destroy(gameObject);

        }

   }

   

       
    }

