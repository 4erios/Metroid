using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Script : MonoBehaviour
{
    
     Animator AnimExplo;
    // Start is called before the first frame update
    void Start()
    {
        AnimExplo = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        StartCoroutine(TimeBeforeDestruction());

    }

    IEnumerator TimeBeforeDestruction()
    {
        AnimExplo.SetTrigger("Explosion");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

       
    }
}
