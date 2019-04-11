using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeScript : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public Transform bombePosition;
    public GameObject BombePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TimeBeforeExplosion());

    }



    IEnumerator TimeBeforeExplosion()
    {
        // Coroutine permettant de faire pop l'explosion après 1 sec 
        yield return new WaitForSeconds(1);
        Instantiate(ExplosionPrefab, bombePosition.position, bombePosition.rotation);
        Destroy(gameObject);
    }

 

    }
   

